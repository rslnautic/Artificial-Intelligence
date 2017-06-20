using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class NodoPF
    {
        public static byte[,] mapNodeStatus = null;
        public NodoPF Padre { get; set; }
        public Estado Estado { get; set; }
        public float gCost = 0f;
        public float hCost = 0f;

        public float fCost {
            get {
                return gCost + hCost;
            }
        }


        public NodoPF(Estado e, NodoPF padre)
        {
            Padre = padre;
            Estado = e;
        }

        public virtual List<NodoPF> Expandir()
        {
            List<Estado> estadosDerivados = Estado.Expandir();
            //Eliminamos bucles simples
            List<NodoPF> nodosExpandidos = new List<NodoPF>();
            foreach (var estado in estadosDerivados)
            {
                if (Padre != null)
                {
                    //if (!Padre.Estado.Equals(estado))
                    //{
                        /*if (mapNodeStatus[(int)estado.Position.x, (int)estado.Position.y] == 0)
                        {*/
                        NodoPF node = new NodoPF(estado, this);
                        node.gCost = Padre.gCost + 1;
                        node.hCost = Distance.EuclideanDistance(estado.Position, PathFinding.final.Estado.Position);
                        nodosExpandidos.Add(node);
                        //mapNodeStatus[(int)estado.Position.x, (int)estado.Position.y] = 1;
                        //}
                    //}
                }
                else
                {
                    NodoPF node = new NodoPF(estado, this);
                    node.gCost += 1;
                    node.hCost = Distance.EuclideanDistance(estado.Position, PathFinding.final.Estado.Position);
                    nodosExpandidos.Add(node);
                }
            }
            return nodosExpandidos;
        }

        public override string ToString()
        {
            var resultado = string.Format(" E: ({0}) despues de {1}\n", Estado.Position, Estado.Accion);
            if (Padre != null)
            {
                resultado = Padre + resultado;
            }
            return resultado;
        }
    }
}
