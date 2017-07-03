using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strips : MonoBehaviour {
	public State initialState;
	public State goal;

	public List<Operator> validOperators;

    public struct ResultadoStrips
    {
        public State sMeta;
        public List<Operator> planMeta;
        public bool hayPlan;
    }

	void Start() {
        Init();
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

	public ResultadoStrips Search(State currentState, List<string> goals, List<Operator> plan) {
        ResultadoStrips resultado; 
        while (!currentState.Contains(goals))
        {
            // (1) elegimos property
            foreach(string property in goals)
            {
                if(!currentState.properties.Contains(property))
                {
                    List<Operator> operatorsThatProduceProperty = getOperatorsWithProperty(property);
                    foreach(Operator oprtr in operatorsThatProduceProperty)
                    {
                        // (3)
                        
                        resultado = Search(currentState, oprtr.getPreconditionList(), plan);
                        currentState = resultado.sMeta;
                        plan = resultado.planMeta;
                        if (!resultado.hayPlan)
                        {
                            return null;
                        }
                        else
                        {
                            resultado.sMeta = oprtr.Apply(currentState);
                            resultado.planMeta = plan;
                            resultado.planMeta.Add(oprtr);
                        }
                        
                    }
                }
            }
        }
        return resultado;
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