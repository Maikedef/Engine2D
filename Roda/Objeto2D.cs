using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum TipoObjeto2D
    {
        Estatico,
        Dinamico
    }

    public struct Vetor2D
    {
        public float x;
        public float y;

        public Vetor2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Vertice2D
    {
        public float x;
        public float y;
        public float rad;
        public float raio;
        public Color cor;
    }

    public class EstiloObjeto2D
    {
        public string nome = "default";
        public Color cor_borda = Color.Black;
        public Color cor_interior = Color.Transparent;
        public float pen_width = 1F;

        public EstiloObjeto2D(string nome)
        {
            this.nome = nome;
        }
    }

    public class ColecaoEstiloObjeto2D : ICollection<EstiloObjeto2D>, IEnumerable, IList<EstiloObjeto2D>
    {
        List<EstiloObjeto2D> estilos = new List<EstiloObjeto2D>();

        public EstiloObjeto2D this[int indice] { get => ((IList<EstiloObjeto2D>)estilos)[indice]; set => ((IList<EstiloObjeto2D>)estilos)[indice] = value; }
        public EstiloObjeto2D this[string nome] {
            get => estilos.Where(x => x.nome == nome).First();
            set {
                var obj = estilos.Where(x => x.nome == nome).First();
                obj = value;
            } }

        public int Count => ((ICollection<EstiloObjeto2D>)estilos).Count;

        public bool IsReadOnly => ((ICollection<EstiloObjeto2D>)estilos).IsReadOnly;

        public void Add(EstiloObjeto2D item)
        {
            ((ICollection<EstiloObjeto2D>)estilos).Add(item);
        }

        public void Clear()
        {
            ((ICollection<EstiloObjeto2D>)estilos).Clear();
        }

        public bool Contains(EstiloObjeto2D item)
        {
            return ((ICollection<EstiloObjeto2D>)estilos).Contains(item);
        }

        public void CopyTo(EstiloObjeto2D[] array, int arrayIndex)
        {
            ((ICollection<EstiloObjeto2D>)estilos).CopyTo(array, arrayIndex);
        }

        public IEnumerator<EstiloObjeto2D> GetEnumerator()
        {
            return ((ICollection<EstiloObjeto2D>)estilos).GetEnumerator();
        }

        public int IndexOf(EstiloObjeto2D item)
        {
            return ((IList<EstiloObjeto2D>)estilos).IndexOf(item);
        }

        public void Insert(int indice, EstiloObjeto2D item)
        {
            ((IList<EstiloObjeto2D>)estilos).Insert(indice, item);
        }

        public bool Remove(EstiloObjeto2D item)
        {
            return ((ICollection<EstiloObjeto2D>)estilos).Remove(item);
        }

        public void RemoveAt(int indice)
        {
            ((IList<EstiloObjeto2D>)estilos).RemoveAt(indice);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<EstiloObjeto2D>)estilos).GetEnumerator();
        }
    }

    public class Objeto2D
    {
        public TipoObjeto2D Tipo = TipoObjeto2D.Estatico;
        public bool visivelTela;

        public string nome;
        public Vetor2D pos = new Vetor2D(0, 0);
        public Vetor2D escala = new Vetor2D(1, 1);

        public float xMax;      // Maior valor de x
        public float xMin;      // Menor valor de x
        public float yMax;      // Maior valor de y
        public float yMin;      // Menor valor de y

        /// <summary>Raio é distância do centro a um ponto qualquer da circunferência.</summary>
        public float raio;
        public float angulo;

        /// <summary>Vértices do ângulo</summary>
        public Vertice2D[] vertices = new Vertice2D[0];
        public bool selecionado;
        public ColecaoEstiloObjeto2D colecaoEstilos = new ColecaoEstiloObjeto2D();
        public EstiloObjeto2D estilo_atual;
        public EstiloObjeto2D estilo_selecao;

        public List<Animacao> animacoes = new List<Animacao>();

        public bool fisica;

        public Objeto2D()
        {
            #region Estilo Padrão
            EstiloObjeto2D padrao = new EstiloObjeto2D("padrao");
            padrao.cor_borda = Color.Black;
            padrao.pen_width = 1F;
            colecaoEstilos.Add(padrao);
            estilo_atual = padrao;
            #endregion

            #region Estilo Seleção
            EstiloObjeto2D selecao = new EstiloObjeto2D("selecao");
            selecao.cor_borda = Color.Blue;
            selecao.pen_width = 2F;
            colecaoEstilos.Add(selecao);
            estilo_selecao = selecao;
            #endregion
        }

        public void AddVertice(Vertice2D vetor)
        {
            Array.Resize(ref vertices, vertices.Length + 1);
            vertices[vertices.Length - 1] = vetor;

            this.xMax = vertices.Max(x => x.x);
            this.xMin = vertices.Min(x => x.x);
            this.yMax = vertices.Max(x => x.y);
            this.yMin = vertices.Min(x => x.y);
        }

        public void DefinirEstilo(EstiloObjeto2D estilo)
        {
            estilo_atual = estilo;
        }

        public void DefinirEstilo(string nome)
        {
            estilo_atual = colecaoEstilos[nome];
        }

        public void GerarCirculo(float raio, int quant = 20)
        {
            GerarObjetoRadial(0, raio, quant);
        }

        public void GerarTriangulo(float raio)
        {
            GerarObjetoRadial(0, raio, 3);
        }

        public void GerarQuadrado(float raio)
        {
            GerarObjetoRadial(45, raio, 4);
        }

        public void GerarPentagono(float raio)
        {
            GerarObjetoRadial(0, raio, 5);
        }

        public void GerarObjetoRadial(float angulo, float raio, int lados)
        {
            this.angulo = angulo;
            this.raio = raio; // raio global
            //vertices = new Vertice2D[lados + 1];
            float rad = (float)(Math.PI * 2 / lados);
            for (int i = 0; i < lados + 1; i++)
            {
                Vertice2D v = new Vertice2D();
                v.x = (float)(Math.Sin(i * rad + Angulo2Radiano(angulo)) * raio);
                v.y = (float)(Math.Cos(i * rad + Angulo2Radiano(angulo)) * raio);
                v.cor = Color.Black;
                v.rad = i * rad;
                v.raio = raio; // raio local
                AddVertice(v);
            }
        }

        public void AtualizarObjeto()
        {
            // TODO: Calcular escala do objeto usando porcentagem das distancias entre xmax e xmin, ymax e ymin

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].x = (float)Math.Sin(vertices[i].rad + Angulo2Radiano(angulo)) * vertices[i].raio;
                vertices[i].y = (float)Math.Cos(vertices[i].rad + Angulo2Radiano(angulo)) * vertices[i].raio;
            }

            this.xMax = vertices.Max(x => x.x);
            this.xMin = vertices.Min(x => x.x);
            this.yMax = vertices.Max(x => x.y);
            this.yMin = vertices.Min(x => x.y);
        }
        private float Angulo2Radiano(float angulo)
        {
            return angulo * (float)Math.PI / 180;
        }
    }
}
