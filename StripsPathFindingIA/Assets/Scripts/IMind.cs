using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public interface IMind
{
    Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos);
}
