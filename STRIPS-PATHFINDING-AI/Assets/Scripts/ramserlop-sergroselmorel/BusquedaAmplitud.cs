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

        public Nodo Buscar(Estado inicio, Estado meta)
        {
            inicio.Accion = "Inicio";
            Nodo inicial = new Nodo(inicio, null);

            Abiertos.Enqueue(inicial);
            while (Abiertos.Count>0)
            {
                Nodo actual = Abiertos.Dequeue();
                if (EsMeta(actual, meta))
                {
                    return actual;

                }
                foreach (var nodo in actual.Expandir())
                {
                    Abiertos.Enqueue(nodo);
                }
            }
            return null;
        }

        public bool EsMeta(Nodo actual, Estado meta)
        {
            return actual.Estado.EsMeta(meta);
        }
    }
}
