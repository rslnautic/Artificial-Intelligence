using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyJug4 : Operator {

	public EmptyJug4 (int x) : base(){
		_preconditionsList.Add (new Jug3 (x));
		_eliminationsList.Add (new Jug3 (x));
		_addList.Add (new Jug3 (0));
	}
}