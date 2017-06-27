using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Nodo
    {
        public Nodo Padre { get; set; }
        public Estado Estado { get; set; }
        public Nodo(Estado e, Nodo padre)
        {
            Padre = padre;
            Estado = e;
        }

        public List<Nodo> Expandir()
        {
            List<Estado> estadosDerivados = Estado.Expandir();
            //Eliminamos bucles simples
            List<Nodo> nodosExpandidos = new List<Nodo>();
            foreach (var estado in estadosDerivados)
            {
                if (Padre != null)
                {
                    if (!Padre.Estado.Equals(estado))
                    {
                        nodosExpandidos.Add(new Nodo(estado, this));
                    }
                }
                else
                {
                    nodosExpandidos.Add(new Nodo(estado, this));
                }
            }
            return nodosExpandidos;
        }

        public override string ToString()
        {
            var resultado = string.Format(" E: ({0},{1}) despues de {2}\n", Estado.J3, Estado.J4, Estado.Accion);
            if (Padre != null)
            {
                resultado = Padre + resultado;
            }
            return resultado;
        }
    }
}
