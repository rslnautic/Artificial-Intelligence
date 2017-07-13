using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : Operator
{
    public GoTo(int obj, Vector2 pos, List<string> preconditions) : base() {
        position = pos;
        _preconditionsList = preconditions;
		_addList.Add ("Object_"+obj);
    }
}
