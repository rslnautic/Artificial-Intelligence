using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Property {

	protected int Liters {
		get;
		set;
	}

	public Property(int liters) {
		Liters = liters;
	}

	public static bool operator == (Property propertyA, Property propertyB) {
        //If Property propertyA and property propertyB are Jug3 or If Property propertyA and property propertyB are Jug4
        if (propertyA is Jug3 && propertyB is Jug3 || propertyA is Jug4 && propertyB is Jug4) {
			return propertyA.Liters == propertyB.Liters;
		} else {
			return false;
		}
	}

	public static bool operator != (Property propertyA, Property property) {
		if (propertyA is Jug3 && property is Jug3 || propertyA is Jug4 && property is Jug4) {
			return propertyA.Liters != property.Liters;
		} else {
			return false;
		}
	}

	/*public bool isEquals(Property propertyToCompare) {
		return this.Liters == propertyToCompare.Liters;
	}*/
}