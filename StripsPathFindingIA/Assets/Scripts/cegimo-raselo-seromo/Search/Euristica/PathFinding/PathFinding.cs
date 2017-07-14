using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class PathFinding {

    public List<NodePathFinding> Abiertos { get; set; }
    public static NodePathFinding inicial;
    public static NodePathFinding final;

    public PathFinding()
    {
        Abiertos = new List<NodePathFinding>();
    }

    public List<NodePathFinding> Buscar(Vector2 initPos, Vector2 endPos)
    {
        Estado inicio = new Estado(initPos, Move.MoveDirection.None);
        Estado fin = new Estado(endPos, Move.MoveDirection.None);
        inicial = new NodePathFinding(inicio, null);
        final = new NodePathFinding(fin, null);

        Abiertos.Add(inicial);
        while (Abiertos.Count > 0)
        {
            NodePathFinding actual = Abiertos.First();
            Abiertos.RemoveAt(0);

            if (actual.Estado.Position == final.Estado.Position)
            {
                NodePathFinding n = actual;
                List<NodePathFinding> normal = new List<NodePathFinding>();
                List<NodePathFinding> reversed = new List<NodePathFinding>();
                while (n != null)
                {
                    normal.Add(n);
                    n = n.Padre;
                }
                for(int i = normal.Count-1; i >= 0; i--)
                {
                    reversed.Add(normal[i]);
                }
                return reversed;
            }
            List<NodePathFinding> actualExpandido = actual.Expandir();
            foreach (var nodo in actualExpandido)
            {
                Abiertos.Add(nodo);
            }
            Abiertos = Abiertos.OrderBy(x => x.FCost).ToList();
        }
        return null;
    }

    /*void ShortedInsert(NodoPF node)
    {

    }*/

    public bool EsMeta(NodePathFinding actual)
    {
        return actual.Estado.Position == final.Estado.Position;
    }
}
