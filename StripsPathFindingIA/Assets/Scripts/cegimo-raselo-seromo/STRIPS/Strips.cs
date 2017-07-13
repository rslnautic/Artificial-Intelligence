using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strips : MonoBehaviour {
	public State initialState;
	public State goal;

	public List<Operator> validOperators;

    public struct ResultadoStrips
    {
        public State state;
        public List<Operator> plan;
        public bool hayPlan;
    }

	void Start() {
        Init();
        List<Operator> plan = new List<Operator>();
        ResultadoStrips res = Search(initialState, goal.properties, plan);
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
        ResultadoStrips resultado = new ResultadoStrips();
        resultado.state = new State(currentState.properties);
        resultado.plan = new List<Operator>();
        foreach(Operator op in plan)
        {
            resultado.plan.Add(op);
        }
        resultado.hayPlan = false;

        while (!currentState.Contains(goals)){
            // (1) elegimos property
            foreach(string property in goals){
                if(!currentState.Contains(property)){
                    // (2) elegimos el operador
                    List<Operator> operatorsThatProduceProperty = getOperatorsWithProperty(property);
                    if (operatorsThatProduceProperty.Count == 0)
                    {
                        // Creemos que se tiene que hacer así. No entendemos muy bien "Entonces falla", 
                        // o si tenemos que devolver algo o no, o hay que hacer otra cosa 
                        resultado.hayPlan = false;
                        break;
                    } else
                    {
                        resultado.hayPlan = true;
                    }
                    Operator oprtr;
                    foreach (Operator operador in operatorsThatProduceProperty){
                        resultado = Search(resultado.state, operador.getPreconditionList(), resultado.plan);
                        if(resultado.hayPlan)
                        {
                            break;
                        }

                    }
                    oprtr.Apply(resultado.state); // aplicamos directamente el operador al resultado.state
                    resultado.plan.Add(oprtr); // añadimos directamente a resultado.plan el operador
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