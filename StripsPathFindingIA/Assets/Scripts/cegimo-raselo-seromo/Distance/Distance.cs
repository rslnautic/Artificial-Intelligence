using UnityEngine;

class Distance
{
    // Manhattan distance
    public static float ManhattanDistance(Vector2 a, Vector2 b)
    {
        checked
        {
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        }
    }

    //Euclidean distance
    public static float EuclideanDistance(Vector2 a, Vector2 b)
    {
        checked
        {
            return Vector2.Distance(a, b);
        }
    }
}

