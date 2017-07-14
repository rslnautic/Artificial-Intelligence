using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

public class DepthMind : IMind { 
    private static DepthMind instance = null;
    private BusquedaProfundidad _busqueda;
    private List<NodeSearch> _resultados = null;
    private Vector2? _lastEndPos = null;


    public static DepthMind getDepthMind()
    {
        if (instance != null)
        {
            return instance;
        }
        else
        {
            return new DepthMind();
        }
    }

    private DepthMind()
    {
        _busqueda = new BusquedaProfundidad();
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos)
    {
        if (_resultados == null || _lastEndPos != endPos)
        {
            _resultados = _busqueda.Buscar(currentPos, endPos);
            _resultados.RemoveAt(0);
            _lastEndPos = endPos;
        }
        if (_resultados.Count != 0)
        {
            NodeSearch nextMoveNode = _resultados[0];
            _resultados.RemoveAt(0);
            return nextMoveNode.Estado.Accion;
        }
        else
        {
            return Move.MoveDirection.None;
        }
    }
}
