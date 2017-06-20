using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PathfindingMind : IMind {

    private PathFinding _pathfinding;
    private NodoPF _resultado = null;

    private Move move;

    public PathfindingMind()
    {
        _pathfinding = new PathFinding();
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, GenerateMap map)
    {
        if (_resultado == null) {
            _resultado = _pathfinding.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right), new Estado(new Vector2(map.cols-1, map.rows-1), map, Move.MoveDirection.Right));
            return _resultado.Estado.Accion; 
        }
        else {
            _resultado = _resultado.Padre;
            return _resultado.Estado.Accion;
        }
    }
}
