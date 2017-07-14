using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class BusquedaAmplitud : BusquedaNoInformada {
    override public List<NodeSearch> Buscar(Vector2 initPos, Vector2 endPos)
    {
        _initState = new Estado(initPos, Move.MoveDirection.None);
        _finalState = new Estado(endPos, Move.MoveDirection.None);
        NodeSearch inicial = new NodeSearch(_initState, null);

        Abiertos.Enqueue(inicial);
        while (Abiertos.Count>0){
            NodeSearch actual = Abiertos.Dequeue();
            if (EsMeta(actual)){
                List<NodeSearch> normal = new List<NodeSearch>();
                List<NodeSearch> steps = new List<NodeSearch>();
                while (actual != null)
                {
                    normal.Add(actual);
                    actual = actual.Padre;
                }
                for (int i = normal.Count - 1; i >= 0; i--)
                {
                    steps.Add(normal[i]);
                }
                Reset();
                return steps;
            }
            List<NodeSearch> actualExpandido = actual.Expandir();
            foreach (var nodo in actualExpandido){
                Abiertos.Enqueue(nodo);
            }
        }
        return null;
    }
}
