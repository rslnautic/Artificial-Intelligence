using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts;

public class PathfindingMind : IMind {

    private static PathfindingMind instance = null;
    private PathFinding _pathfinding;
    private List<NodePathFinding> _resultados = null;
    private Vector2? _lastEndPos = null;

    public static PathfindingMind getPathfindingMind()
    {
        if (instance != null)
        {
            return instance;
        }
        else
        {
            return new PathfindingMind();
        }
    }

    private PathfindingMind()
    {
        _pathfinding = new PathFinding();
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos)
    {
        if (_resultados == null || _lastEndPos != endPos) {
            _resultados = _pathfinding.Buscar(currentPos, endPos);
            _resultados.RemoveAt(0);
            _lastEndPos = endPos;
        }
        if(_resultados.Count != 0)
        {
            NodePathFinding n = _resultados[0];
            _resultados.RemoveAt(0);
            return n.Estado.Accion;
        } else
        {
            return Move.MoveDirection.None;
        }
    }
}
