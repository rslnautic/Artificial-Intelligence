using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {
	public List<string> properties;

    //Constructor por defecto
	public State() {
		properties = new List<string> ();
	}

    //Constructor con la lista de propiedades   (No se usa por ahora)
	public State(List<string> listOfProperties) {
		properties = new List<string> (listOfProperties);
	}

    //
	public State(int j3Liters, int j4Liters){
		properties = new List<string>();

		Jug3 Jug3 = new Jug3(j3Liters);
		Jug4 Jug4 = new Jug4(j4Liters);

		properties.Add(Jug3);
		properties.Add(Jug4);
	}
}