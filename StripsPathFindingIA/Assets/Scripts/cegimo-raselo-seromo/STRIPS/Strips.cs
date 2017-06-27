using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strips {
	public State initialState;
	public State goal;

	public List<Operator> validOperators;
	public static int maxCapacityJ3 = 3, maxCapacityJ4 = 4;

	public Strips(State state) {

		// Seteamos el estado inicial
		initialState = state;

		// Seteamos nuestro goal
		goal = new State();

        //Le comunicamos a STRIPS cual es nuestro estado meta (compuesto de propiedades)
        for (int i = 0; i <= 4; i++)
        {
            goal.properties.Add("Object_" + i);
        }

        // Rellenamos el array de operadores
        validOperators = new List<Operator>();

        for (int i = 1; i <= maxCapacityJ3; i++)
        {
            validOperators.Add(new EmptyJug3(i));
        }

        /*for (int i = 1; i <= maxCapacityJ3; i++) {
			validOperators.Add(new EmptyJug3(i));
		}

		for (int i = 1; i <= maxCapacityJ4; i++) {
			validOperators.Add(new EmptyJug4(i));
		}

		for (int i = 0; i < maxCapacityJ3; i++) {
			validOperators.Add(new FillJug3(i));
		}

		for (int i = 0; i < maxCapacityJ3; i++) {
			validOperators.Add(new FillJug4(i));
		}

		for (int i = 1; i <= maxCapacityJ3; i++) {
			for (int j = 0; j < maxCapacityJ4; j++) {
				validOperators.Add(new PassJug3ToJug4(i,j));
			}
		}

		for (int i = 1; i <= maxCapacityJ4; i++) {
			for (int j = 0; j < maxCapacityJ3; j++) {
				validOperators.Add(new PassJug4ToJug3(i,j));
			}
		}*/
    }

    //Está prácticamente todo bien.
    //Excepto este método, que es el de la búsqueda recursiva
    //De la solución
	public List<Operator> Search(Property pro) {
		State currentState = initialState;
		List <Operator> possibleOperators = new List<Operator> ();

		// compruebo si esta contenido el goal en el current state
		if(goal.properties.Contains(pro)) {
            //Sale de la búsqueda
            //Esto está mal.
            return null;
		}

		foreach (Property property in goal.properties) {
			List<Operator> operatorsThatProduceProperty = getOperatorsWithProperty(property);
			foreach (Operator op in operatorsThatProduceProperty) {
				if (op.isApplicable(currentState)){
					op.Apply (currentState);
                    possibleOperators.Add(op);
				} else {
					List<Property> preconditions = op.getPreconditionList ();
					preconditions.RemoveAll (item => currentState.properties.Contains (item));
					foreach(Property precondition in preconditions) {
						Search(precondition);
					}
				}
			}
		}
        return null;
	}

	public List<Operator> getOperatorsWithProperty(Property property) {
		List<Operator> operatorList = new List<Operator>();
		foreach (Operator op in validOperators) {
			if (op.Produces(property)) {
				operatorList.Add (op);
			}
		}
		return operatorList;
	}
}