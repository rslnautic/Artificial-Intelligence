using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassJug4ToJug3 : Operator {

	public PassJug4ToJug3 (int x, int y) : base(){
		int pasamos = Math.Min(x, Strips.maxCapacityJ3 - y);
		int newJ3 = y + pasamos;
		int newJ4 = x - pasamos;

		_preconditionsList.Add (new Jug3 (x));
		_preconditionsList.Add (new Jug4 (y));
		_eliminationsList.Add (new Jug3 (x));
		_eliminationsList.Add (new Jug4 (y));
		_addList.Add (new Jug3 (newJ3));
		_addList.Add (new Jug4(newJ4));
	}
}