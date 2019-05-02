using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda
{
    public struct Vector2D
    {
        public float x;
        public float y;

        public Vector2D(float x, float y)
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
        public float new_rad;
        public float raio;
        public Color cor;
    }

    public class EstiloObjeto2D
    {
        public string nome = "default";
        public Color cor = Color.Black;
        public float pen_width = 1F;
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
        public string nome;
        public Vector2D pos;
        
        public float raio;
        public float angulo;
        public Vertice2D[] vertices;
        public bool selecionado;
        public ColecaoEstiloObjeto2D colecaoEstilos = new ColecaoEstiloObjeto2D();
        public EstiloObjeto2D estilo_atual;
        public EstiloObjeto2D estilo_selecao;

        public bool fisica;

        public Objeto2D()
        {
            #region Estilo Padrão
            EstiloObjeto2D padrao = new EstiloObjeto2D();
            padrao.cor = Color.Black;
            padrao.pen_width = 1F;
            padrao.nome = "padrao";
            colecaoEstilos.Add(padrao);
            estilo_atual = padrao;
            #endregion

            #region Estilo Seleção
            EstiloObjeto2D selecao = new EstiloObjeto2D();
            selecao.cor = Color.Blue;
            selecao.pen_width = 2F;
            selecao.nome = "selecao";
            colecaoEstilos.Add(selecao);
            estilo_selecao = selecao;
            #endregion
        }

        public void AddVertice(Vertice2D vetor)
        {
            Array.Resize(ref vertices, vertices.Length + 1);
            vertices[vertices.Length - 1] = vetor;
        }

        public void GerarCirculo(float raio, int quant = 20)
        {
            GerarObjetoRadial(raio, quant);
        }

        public void GerarTriangulo(float raio)
        {
            GerarObjetoRadial(raio, 3);
        }

        public void GerarQuadrado(float raio)
        {
            GerarObjetoRadial(raio, 4);
            angulo = 45;
        }

        public void GerarPentagono(float raio)
        {
            GerarObjetoRadial(raio, 5);
        }

        public void GerarObjetoRadial(float raio, int lados)
        {
            this.raio = raio;
            vertices = new Vertice2D[lados + 1];
            float rad = (float)(Math.PI * 2 / lados);
            for (int i = 0; i < lados + 1; i += 1)
            {
                Vertice2D v = new Vertice2D();
                v.x = (float)(Math.Sin(i * rad) * raio);
                v.y = (float)(Math.Cos(i * rad) * raio);
                v.cor = Color.Black;
                v.rad = i * rad;
                v.raio = raio;
                vertices[i] = v;
            }
        }

        public void AtualizarObjeto()
        {
            float rad_diff = vertices[0].raio - Angulo2Radiano(angulo);

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].x = (float)Math.Sin(vertices[i].rad + rad_diff) * vertices[i].raio;
                vertices[i].y = (float)Math.Cos(vertices[i].rad + rad_diff) * vertices[i].raio;
            }
        }
        private float Angulo2Radiano(float angulo)
        {
            return angulo * (float)Math.PI / 180;
        }
    }
}
