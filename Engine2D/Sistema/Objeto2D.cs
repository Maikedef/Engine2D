using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Sistema
{
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
    }

    /// <summary>
    /// Tipo abstrato que envolve tanto objetos visíveis e invisíveis do simulador
    /// </summary>
    public abstract class Objeto2D : ICloneable
    {
        #region Propriedades
        /// <summary>Id do objeto</summary>
        public int Id { get; set; }
        /// <summary>Nome do objeto</summary>
        public string Nome { get; set; }
        
        /// <summary>Distância do centro ao ponto máximo da circunferência.</summary>
        public float Raio { get; set; }
        /// <summary>Ângulo Z do objeto</summary>
        public float Angulo { get; set; }
        /// <summary>Ângulo X do objeto</summary>
        public float AnguloX { get; set; }
        /// <summary>Ângulo Y do objeto</summary>
        public float AnguloY { get; set; }
        /// <summary>Ponto X máximo do objeto</summary>
        public float XMax { get; set; }
        /// <summary>Ponto X mínimo do objeto</summary>
        public float XMin { get; set; }
        /// <summary>Ponto Y máximo do objeto</summary>
        public float YMax { get; set; }
        /// <summary>Ponto Y mínimo do objeto</summary>
        public float YMin { get; set; }

        /// <summary>Cor de representação abstrata do objeto</summary>
        public RGBA Cor { get; set; }

        /// <summary>Define se o objeto está selecionado em modo Editor</summary>
        public bool Selecionado { get; set; }
        public Transformacao Transformação { get; private set; }
        #endregion

        #region Campos
        /// <summary>Posição do objeto</summary>
        public Vetor2D Pos = new Vetor2D(0, 0);
        /// <summary>Escala do objeto</summary>
        public Vetor2D Escala = new Vetor2D(1, 1);
        /// <summary>Ponto central do objeto</summary>
        public Vetor2D Centro = new Vetor2D(0, 0);
        #endregion

        #region Arrays
        /// <summary>Vértices do objeto</summary>
        public Vertice2D[] Vertices = new Vertice2D[0];
        /// <summary>Animações do objeto</summary>
        public List<Animacao2D> Animacoes { get; set; } = new List<Animacao2D>();
        /// <summary>Pivôs do objeto</summary>
        public List<Pivo2D> Pivos { get; set; } = new List<Pivo2D>();
        #endregion

        public Objeto2D()
        {
            Transformação = new Transformacao(this);
        }

        /// <summary>
        /// Adiciona vértice ao objeto
        /// </summary>
        /// <param name="v"></param>
        public virtual void AdicionarVertice(Vertice2D v)
        {
            Array.Resize(ref Vertices, Vertices.Length + 1);
            Vertices[Vertices.Length - 1] = v;
            AtualizarXYMinMax();
        }

        public virtual void Animar(string nome)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Move o objeto incrementando as posições x e y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Mover(float x, float y)
        {
            Pos.x += x;
            Pos.x += y;
        }

        /// <summary>
        /// Move o objeto incrementando as posições x e y
        /// </summary>
        /// <param name="pos"></param>
        public virtual void Mover(Vetor2D pos)
        {
            Pos.x += pos.x;
            Pos.x += pos.y;
        }

        /// <summary>
        /// Move o objeto incrementando a posição x
        /// </summary>
        /// <param name="x"></param>
        public virtual void MoverX(float x)
        {
            Pos.x = x;
        }

        /// <summary>
        /// Move o objeto incrementando a posição y
        /// </summary>
        /// <param name="y"></param>
        public virtual void MoverY(float y)
        {
            Pos.y = y;
        }

        /// <summary>
        /// Posiciona o objeto na posição x e y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Posicionar(float x, float y)
        {
            Pos.x = x;
            Pos.y = y;
        }

        /// <summary>
        /// Posiciona o objeto na posição x e y
        /// </summary>
        /// <param name="pos"></param>
        public virtual void Posicionar(Vetor2D pos)
        {
            Pos.x = pos.x;
            Pos.y = pos.y;
        }

        /// <summary>
        /// Posiciona o objeto na posição x
        /// </summary>
        /// <param name="x"></param>
        public virtual void PosicionarX(float x)
        {
            Pos.x = x;
        }

        /// <summary>
        /// Posiciona o objeto na posição y
        /// </summary>
        /// <param name="y"></param>
        public virtual void PosicionarY(float y)
        {
            Pos.y = y;
        }

        /// <summary>
        /// Gira o objeto
        /// </summary>
        /// <param name="graus"></param>
        public virtual void Girar(float graus)
        {
            Angulo += graus;
            AtualizarGeometria();
        }

        /// <summary>
        /// Gira o objeto no eixo x
        /// </summary>
        /// <param name="graus"></param>
        public virtual void GirarX(float graus)
        {
            AnguloX += graus;
            AtualizarGeometria();
        }

        /// <summary>
        /// Gira o objeto no eixo y
        /// </summary>
        /// <param name="graus"></param>
        public virtual void GirarY(float graus)
        {
            AnguloY += graus;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define o ângulo do objeto
        /// </summary>
        /// <param name="angulo"></param>
        public virtual void DefinirAngulo(float angulo)
        {
            Angulo = angulo;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define o ângulo do eixo x do objeto
        /// </summary>
        /// <param name="angulo"></param>
        public virtual void DefinirAnguloX(float angulo)
        {
            AnguloX = angulo;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define o ângulo do eixo y do objeto
        /// </summary>
        /// <param name="angulo"></param>
        public virtual void DefinirAnguloY(float angulo)
        {
            AnguloY = angulo;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define o raio do objeto, isto é, a distância do centro ao ponto máximo da circunferência.
        /// </summary>
        /// <param name="raio"></param>
        public virtual void DefinirRaio(float raio)
        {
            int idx = IndicePorMaiorRaio();

            float raioMax = Vertices[idx].raio;
            float diff = raio - raioMax;
            if (diff == 0) return;

            // Define os raios internos de cada vértice proporcionalmente ao novo raio de ponto máximo da circunferência
            float percentual = diff / raioMax * 100; // Percentual da diferença
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i].raio += Vertices[i].raio * percentual / 100;
            }
            Raio = raio;
            AtualizarGeometria();
        }

        private int IndicePorMaiorRaio()
        {
            int idxMax = 0;
            float v = float.MinValue;

            for (int i = 0; i < Vertices.Length; i++)
            {
                if (Vertices[i].raio > v)
                {
                    v = Vertices[i].raio;
                    idxMax = i;
                }
            }
            return idxMax;
        }

        /// <summary>
        /// Incrementa escala x e y do objeto
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Escalar(float x, float y)
        {
            Escala.x += x;
            Escala.y += y;
            AtualizarGeometria();
        }

        /// <summary>
        /// Incrementa escala x do objeto
        /// </summary>
        /// <param name="x"></param>
        public virtual void EscalarX(float x)
        {
            Escala.x += x;
            AtualizarGeometria();
        }

        /// <summary>
        /// Incrementa escala y do objeto
        /// </summary>
        /// <param name="y"></param>
        public virtual void EscalarY(float y)
        {
            Escala.y += y;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define escala x e y do objeto
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void DefinirEscala(float x, float y)
        {
            Escala.x = x;
            Escala.y = y;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define escala x do objeto
        /// </summary>
        /// <param name="x"></param>
        public virtual void DefinirEscalaX(float x)
        {
            Escala.x = x;
            AtualizarGeometria();
        }

        /// <summary>
        /// Define escala y do objeto
        /// </summary>
        /// <param name="y"></param>
        public virtual void DefinirEscalaY(float y)
        {
            Escala.y = y;
            AtualizarGeometria();
        }

        /// <summary>Inverte o eixo x do objeto</summary>
        public virtual void InverterEixoX()
        {
            throw new NotImplementedException();
        }

        /// <summary>Inverte o eixo y do objeto</summary>
        public virtual void InverterEixoY()
        {
            throw new NotImplementedException();
        }

        /// <summary>Atualiza os pontos máximos e mínimos da geometria</summary>
        public void AtualizarXYMinMax()
        {
            XMax = Vertices.Max(x => x.x);
            XMin = Vertices.Min(x => x.x);
            YMax = Vertices.Max(x => x.y);
            YMin = Vertices.Min(x => x.y);
        }

        /// <summary>Atualiza o raio pelo ponto máximo da circunferência. Quando há variação de raios entre uma vértice e outra essa atualização é necessária.</summary>
        public float AtualizarRaio()
        {
            Raio = Vertices.Max(x => x.raio);
            return Raio;
        }

        /// <summary>Atualiza todas as vértices considerando fatores como: raio, ângulo, escala, etc.</summary>
        public virtual void AtualizarGeometria()
        {
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i].x = (float)Math.Sin(Vertices[i].rad + Util.Angulo2Radiano(Angulo)) * Vertices[i].raio * Escala.x;
                Vertices[i].y = (float)Math.Cos(Vertices[i].rad + Util.Angulo2Radiano(Angulo)) * Vertices[i].raio * Escala.y;
            }
            AtualizarXYMinMax();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
