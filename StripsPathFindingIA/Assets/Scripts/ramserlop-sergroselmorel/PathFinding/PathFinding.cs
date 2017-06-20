using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using Assets.Scripts;


public class PathFinding {

    public Queue<NodoPF> Abiertos { get; set; }
    public PathFinding()
    {
        Abiertos = new Queue<NodoPF>();
    }

    public NodoPF Buscar(Estado inicio)
    {
        inicio.Accion = Move.MoveDirection.Right;
        NodoPF inicial = new NodoPF(inicio, null);

        Abiertos.Enqueue(inicial);
        while (Abiertos.Count > 0)
        {
            NodoPF actual = Abiertos.Dequeue();
            if (EsMeta(actual))
            {
                return actual;

            }
            List<NodoPF> actualExpandido = actual.Expandir();
            foreach (var nodo in actualExpandido)
            {
                Abiertos.Enqueue(nodo);
            }
        }
        return null;
    }

    void shortedInsert(NodoPF node)
    {

    }

    public bool EsMeta(NodoPF actual)
    {
        return actual.Estado.EsMeta();
    }
}
