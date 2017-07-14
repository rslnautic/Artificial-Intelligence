using UnityEngine;
using System.Collections;

public class RandomMind : IMind {
    public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos)
    {
        int val = Random.Range(0, 4);
        if (val == 0) return Move.MoveDirection.Up;
        if (val == 1) return Move.MoveDirection.Down;
        if (val == 2) return Move.MoveDirection.Left;
        return Move.MoveDirection.Right;
    }
}
