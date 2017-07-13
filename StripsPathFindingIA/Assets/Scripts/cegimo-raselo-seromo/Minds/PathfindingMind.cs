using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts;

public class PathfindingMind : IMind {

    private PathFinding _pathfinding;
    private List<NodoPF> _resultados = null;
    private Vector2? _lastEndPos = null;

    private Move move;

    public PathfindingMind()
    {
        _pathfinding = new PathFinding();
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos, GenerateMap map)
    {
        if (_resultados == null || _lastEndPos != endPos) {
            _resultados = _pathfinding.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right), new Estado(endPos, map, Move.MoveDirection.Right));
            _resultados.RemoveAt(0);
            _lastEndPos = endPos;
        }
        if(_resultados.Count != 0)
        {
            NodoPF n = _resultados[0];
            _resultados.RemoveAt(0);
            return n.Estado.Accion;
        } else
        {
            return Move.MoveDirection.Right;
        }
    }
}
