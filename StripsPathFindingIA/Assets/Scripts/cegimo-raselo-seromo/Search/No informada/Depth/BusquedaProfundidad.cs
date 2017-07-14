using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class BusquedaProfundidad {

    private Estado _initState = null;
    private Estado _finalState = null;

    public BusquedaProfundidad()
    {

    }

    public List<NodeSearch> Buscar (Vector2 initPos, Vector2 endPos)
    {
        _initState = new Estado(initPos, Move.MoveDirection.None);
        _finalState = new Estado(endPos, Move.MoveDirection.None);
        NodeSearch inicial = new NodeSearch(_initState, null);
        NodeSearch final = new NodeSearch(_finalState, null);
        int depth = 0;
        while(true)
        {
            NodeSearch resultado = Buscar(inicial, final, depth);
            if(resultado != null)
            {
                if (resultado.Estado.Position == endPos)
                {
                    List<NodeSearch> normal = new List<NodeSearch>();
                    List<NodeSearch> steps = new List<NodeSearch>();
                    while (resultado != null)
                    {
                        normal.Add(resultado);
                        resultado = resultado.Padre;
                    }
                    for (int i = normal.Count - 1; i >= 0; i--)
                    {
                        steps.Add(normal[i]);
                    }
                    return steps;
                }
            }
            depth++;
        }
    }

    public NodeSearch Buscar(NodeSearch node, NodeSearch target, int depth)
    {
        if (depth == 0 && node.Estado.Position == target.Estado.Position) {
            return node;
        }
        if (depth > 0)
        {
            List<NodeSearch> childs = node.ExpandirD();
            for(int i = 0; i < childs.Count; i++)
            {
                NodeSearch res = Buscar(childs[i], target, depth - 1);
                if (res != null)
                    return res;
            } 
        }
        return null;
    }
}
