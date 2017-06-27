using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassJug3ToJug4 : Operator {

	public PassJug3ToJug4 (int x, int y) : base(){
		int pasamos = Math.Min(x, Strips.maxCapacityJ4 - y);
		int newJ4 = y + pasamos;
		int newJ3 = x - pasamos;

		_preconditionsList.Add (new Jug3 (x));
		_preconditionsList.Add (new Jug4 (y));
		_eliminationsList.Add (new Jug3 (x));
		_eliminationsList.Add (new Jug4 (y));
		_addList.Add (new Jug3 (newJ3));
		_addList.Add (new Jug4(newJ4));
	}
}