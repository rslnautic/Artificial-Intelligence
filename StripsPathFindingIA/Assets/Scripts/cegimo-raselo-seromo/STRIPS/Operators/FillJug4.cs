﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillJug4 : Operator {

	public FillJug4 (int x) : base(){
		_preconditionsList.Add (new Jug3 (x));
		_eliminationsList.Add (new Jug3 (x));
		_addList.Add (new Jug3 (Strips.maxCapacityJ4));
	}
}