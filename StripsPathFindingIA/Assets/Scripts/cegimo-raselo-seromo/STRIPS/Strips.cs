using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strips : MonoBehaviour {
	public State initialState;
	public State goal;

	public List<Operator> validOperators;

	void Start() { 
		// Seteamos el estado inicial
		initialState = new State();

        // Seteamos nuestro goal
        goal = new State();
        ItemLogic goalLogic = GameObject.FindGameObjectWithTag("Goal").GetComponent<ItemLogic>();
        
        foreach (GameObject ptr in goalLogic.Required)
        {
            goal.properties.Add(ptr.name);
        }   

        // Rellenamos el array de operadores
        validOperators = new List<Operator>();
        List<GameObject> objsItem = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));

        for(int i = 0; i < objsItem.Count; i++)
        {
            ItemLogic itLogic = objsItem[i].GetComponent<ItemLogic>();
            List<string> itemProperties = new List<string>();
            foreach(GameObject ptr in itLogic.Required)
            {
                itemProperties.Add(ptr.name);
            }
            validOperators.Add(new GoTo(i, objsItem[i].transform.position, itemProperties));
        }
    }

    //Está prácticamente todo bien.
    //Excepto este método, que es el de la búsqueda recursiva
    //De la solución
	public List<Operator> Search(string property) {
		/*State currentState = initialState;
		List <Operator> possibleOperators = new List<Operator> ();

		// compruebo si esta contenido el goal en el current state
		if(goal.properties.Contains(property)) {
            //Sale de la búsqueda
            //Esto está mal.
            return null;
		}*/

		/*foreach (Property property in goal.properties) {
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
		}*/
        return null;
	}

	public List<Operator> getOperatorsWithProperty(string property) {
		List<Operator> operatorList = new List<Operator>();
		foreach (Operator op in validOperators) {
			if (op.Produces(property)) {
				operatorList.Add (op);
			}
		}
		return operatorList;
	}
}