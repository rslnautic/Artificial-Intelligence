using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BusquedaAmplitud : BusquedaNoInformada {
        override public NodeSearch Buscar(Vector2 initPos, Vector2 endPos)
        {
            _initState = new Estado(initPos, Move.MoveDirection.None);
            _finalState = new Estado(endPos, Move.MoveDirection.None);
            NodeSearch inicial = new NodeSearch(_initState, null);

            Abiertos.Enqueue(inicial);
            while (Abiertos.Count>0){
                NodeSearch actual = Abiertos.Dequeue();
                if (EsMeta(actual)){
                    return actual;
                }
                List<NodeSearch> actualExpandido = actual.Expandir();
                foreach (var nodo in actualExpandido){
                    Abiertos.Enqueue(nodo);
                }
            }
            return null;
        }
    }
}
