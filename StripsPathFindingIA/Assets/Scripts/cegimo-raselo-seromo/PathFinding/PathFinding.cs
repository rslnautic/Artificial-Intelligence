using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;


public class PathFinding {

    public List<NodoPF> Abiertos { get; set; }
    public static NodoPF inicial;
    public static NodoPF final;

    public PathFinding()
    {
        Abiertos = new List<NodoPF>();
    }

    public NodoPF Buscar(Estado inicio, Estado fin)
    {
        inicial = new NodoPF(inicio, null);
        final = new NodoPF(fin, null);

        Abiertos.Add(inicial);
        while (Abiertos.Count > 0)
        {
            NodoPF actual = Abiertos.First();
            Abiertos.RemoveAt(0);

            if (actual == final)
            {
                return actual;
            }
            List<NodoPF> actualExpandido = actual.Expandir();
            foreach (var nodo in actualExpandido)
            {
                Abiertos.Add(nodo);
            }
            Abiertos = Abiertos.OrderBy(x => x.fCost).ToList();
        }
        return null;
    }

    /*void ShortedInsert(NodoPF node)
    {

    }*/

    public bool EsMeta(NodoPF actual)
    {
        return actual.Estado.EsMeta();
    }
}
