using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PathfindingMind : IMind {

    private PathFinding _pathfinding;
    private NodoPF _resultado = null;

    private Move move;

    private float[,] fstar = null;

    public PathfindingMind()
    {
        _pathfinding = new PathFinding();

        //generation of heuristic distances
        //From every node to the end (top tight)
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, GenerateMap map)
    {
        if (fstar == null){
            fstar = GenerateFStar(map);
        }
        if (_resultado == null) {
            /*_resultado = _pathfinding.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right));
            return _resultado.Estado.Accion;*/
        }
        else {
            /*_resultado = _resultado.Padre;
            return _resultado.Estado.Accion;*/
        }

        //PLACEHOLDER
        return Move.MoveDirection.Right;
    }

    public float[,] GenerateFStar(GenerateMap map)
    {

        fstar = new float[map.cols, map.rows];

        foreach (GenerateMap.TileType tile in map.GeneratedMap)
        {

        }

        return fstar;
    }
}
