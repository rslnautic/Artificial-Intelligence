using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMind : IMind {
	
	/*private BusquedaAmplitud _busqueda;
	private Nodoo _resultado;*/

	public Move.MoveDirection GetNextMove(Vector2 currentPos, GenerateMap map)
	{
		int val = Random.Range(0, 4);
		if (val == 0) return Move.MoveDirection.Up;
		if (val == 1) return Move.MoveDirection.Down;
		if (val == 2) return Move.MoveDirection.Left;
		return Move.MoveDirection.Right;
	}
}
