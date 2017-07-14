using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class PathFinding {

    public List<NodePathFinding> Abiertos { get; set; }
    public static NodePathFinding inicial = null;
    public static NodePathFinding final = null;

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

            if (EsMeta(actual))
            {
                List<NodePathFinding> normal = new List<NodePathFinding>();
                List<NodePathFinding> steps = new List<NodePathFinding>();
                while (actual != null)
                {
                    normal.Add(actual);
                    actual = actual.Padre;
                }
                for(int i = normal.Count-1; i >= 0; i--)
                {
                    steps.Add(normal[i]);
                }
                Reset();
                return steps;
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

    public bool EsMeta(NodePathFinding actual)
    {
        return actual.Estado.Position == final.Estado.Position;
    }

    public void Reset()
    {
        Abiertos.Clear();
        inicial = null;
        final = null;
    }
}
