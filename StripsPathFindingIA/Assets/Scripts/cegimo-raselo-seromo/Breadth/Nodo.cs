using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Nodo
    {
        public static byte[,] mapNodeStatus = null;
        public Nodo Padre { get; set; }
        public Estado Estado { get; set; }
        public Nodo(Estado e, Nodo padre){
            Padre = padre;
            Estado = e;
        }

        public virtual List<Nodo> Expandir(){
            List<Estado> estadosDerivados = Estado.Expandir();
            //Eliminamos bucles simples
            List<Nodo> nodosExpandidos = new List<Nodo>();
            foreach (var estado in estadosDerivados){
                if (Padre != null){
                    if (!Padre.Estado.Equals(estado)){
                        if(mapNodeStatus[(int) estado.Position.x, (int) estado.Position.y] == 0){
                            nodosExpandidos.Add(new Nodo(estado, this));
                            mapNodeStatus[(int)estado.Position.x, (int)estado.Position.y] = 1;
                        }
                    }
                }
                else{
                    nodosExpandidos.Add(new Nodo(estado, this));
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
