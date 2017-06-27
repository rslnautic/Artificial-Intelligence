using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyJug3 : Operator {

	public EmptyJug3 (int x) : base(){
		_preconditionsList.Add (new Jug3 (x));
		_eliminationsList.Add (new Jug3 (x));
		_addList.Add (new Jug3 (0));
	}
}