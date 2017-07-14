using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    abstract public class BusquedaNoInformada
    {
        public Queue<NodeSearch> Abiertos { get; set; }
        protected Estado _initState = null;
        protected Estado _finalState = null;
        private static byte[,] _mapNodeStatus = null;

        public static byte[,] MapNodeStatus
        {
            get
            {
                if (_mapNodeStatus == null)
                {
                    _mapNodeStatus = new byte[GameManager.instance.Map.cols, GameManager.instance.Map.rows];
                }
                return _mapNodeStatus;
            }
        }
        
        public BusquedaNoInformada()
        {
            Abiertos = new Queue<NodeSearch>();
        }
        abstract public NodeSearch Buscar(Vector2 initPos, Vector2 endPos);
        protected bool EsMeta(NodeSearch actual)
        {
            return actual.Estado.Position == _finalState.Position;
        }
    }
}
