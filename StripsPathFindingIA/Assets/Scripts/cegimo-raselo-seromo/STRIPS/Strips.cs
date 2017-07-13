using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strips : MonoBehaviour {
	public State initialState;
	public State goal;
    public static List<Operator> plan;


    public List<Operator> validOperators;

    public struct ResultadoStrips
    {
        public State state;
        public List<Operator> plan;
        public bool hayPlan;
    }

	void Start() {
        Init();
        plan = Search(initialState, goal.properties);
    }

    private void Init()
    {
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

        for (int i = 0; i < objsItem.Count; i++)
        {
            ItemLogic itLogic = objsItem[i].GetComponent<ItemLogic>();
            List<string> itemProperties = new List<string>();
            foreach (GameObject ptr in itLogic.Required)
            {
                itemProperties.Add(ptr.name);
            }
            validOperators.Add(new GoTo(i, objsItem[i].transform.position, itemProperties));
        }
    }

	public List<Operator> Search(State currentState, List<string> goals) {
        List<Operator> plan = new List<Operator>();

        while (!currentState.Contains(goals)){
            foreach(string property in goals){
                if(!currentState.Contains(property)){
                    List<Operator> operatorsThatProduceProperty = getOperatorsWithProperty(property);
                    if (operatorsThatProduceProperty.Count == 0)
                        return null;
 
                    foreach (Operator oprtr in operatorsThatProduceProperty){
                        List<Operator> primePlan = Search(currentState, oprtr.getPreconditionList());
                        if (primePlan == null)
                            return null;
                        foreach (Operator op in primePlan)
                        {
                            op.Apply(currentState);
                            plan.Add(op);
                        }
                            
                        oprtr.Apply(currentState);
                        plan.Add(oprtr);
                    }
                }
            }
        }
        return plan;
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