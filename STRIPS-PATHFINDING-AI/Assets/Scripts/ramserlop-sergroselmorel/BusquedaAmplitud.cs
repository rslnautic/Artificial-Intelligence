using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;

namespace Assets.Scripts
{
    public class BusquedaAmplitud
    {
        public Queue<Nodo> Abiertos { get; set; }
        public BusquedaAmplitud()
        {
            Abiertos = new Queue<Nodo>();
        }

        public Nodo Buscar(Estado inicio)
        {
            inicio.Accion = Move.MoveDirection.Right;
            Nodo inicial = new Nodo(inicio, null);

            Abiertos.Enqueue(inicial);
            while (Abiertos.Count>0)
            {
                Nodo actual = Abiertos.Dequeue();
                if (EsMeta(actual))
                {
                    return actual;

                }
                List<Nodo> actualExpandido = actual.Expandir();
                foreach (var nodo in actualExpandido)
                {
                    Abiertos.Enqueue(nodo);
                }
            }
            return null;
        }

        public bool EsMeta(Nodo actual)
        {
            return actual.Estado.EsMeta();
        }
    }
}
