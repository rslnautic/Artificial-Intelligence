using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts;

public class PathfindingMind : IMind {

    private PathFinding _pathfinding;
    private List<NodoPF> _resultados = null;

    private Move move;

    public PathfindingMind()
    {
        _pathfinding = new PathFinding();
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, GenerateMap map)
    {
        if (_resultados == null) {
            _resultados = _pathfinding.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right), new Estado(new Vector2(map.cols-1, map.rows-1), map, Move.MoveDirection.Right));
            _resultados.RemoveAt(0);
        }
        NodoPF n = _resultados.First();
        _resultados.RemoveAt(0);
        return n.Estado.Accion;
    }
}
