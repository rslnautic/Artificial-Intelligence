using System.Collections.Generic;
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

    void ShortedInsert(NodoPF node)
    {

    }

    public bool EsMeta(NodoPF actual)
    {
        return actual.Estado.EsMeta();
    }
}
