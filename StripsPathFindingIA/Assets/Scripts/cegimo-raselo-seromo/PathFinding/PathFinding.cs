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

    public List<NodoPF> Buscar(Estado inicio, Estado fin)
    {
        inicial = new NodoPF(inicio, null);
        final = new NodoPF(fin, null);

        Abiertos.Add(inicial);
        while (Abiertos.Count > 0)
        {
            NodoPF actual = Abiertos.First();
            Abiertos.RemoveAt(0);

            if (actual.Estado.Position == final.Estado.Position)
            {
                NodoPF n = actual;
                List<NodoPF> normal = new List<NodoPF>();
                List<NodoPF> reversed = new List<NodoPF>();
                while (n != null)
                {
                    normal.Add(n);
                    n = n.Padre;
                }
                for(int i = normal.Count-1; i > 0; i--)
                {
                    reversed.Add(normal[i]);
                }
                return reversed;
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
