using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

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
    abstract public List<NodeSearch> Buscar(Vector2 initPos, Vector2 endPos);
    protected bool EsMeta(NodeSearch actual)
    {
        return actual.Estado.Position == _finalState.Position;
    }

    public void Reset()
    {
        Abiertos.Clear();
        _initState = null;
        _finalState = null;
        _mapNodeStatus = null;
    }
}

