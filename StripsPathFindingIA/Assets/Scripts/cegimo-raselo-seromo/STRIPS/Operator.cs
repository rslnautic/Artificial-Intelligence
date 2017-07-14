using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operator {

    public Vector2 position;
    protected List<string> _addList;
	protected List<string> _preconditionsList;
	protected List<string> _eliminationsList;

	public Operator() {
        position = new Vector2();
        _addList = new List<string> ();
		_preconditionsList = new List<string> ();
		_eliminationsList = new List<string> ();
	}

    //Comprueba si el operador contiene la propiedad property en la lista de adiciones.
	public bool Produces(string property){
		return _addList.Contains(property);
	}

    //Aplica el operador al mundo, cambiando así sus propiedades
    //Añade y elimina propiedades para cambiar su estado
	public State Apply(State state){
        Delete(state);
        Add(state);
        return state;
    }

	private void Delete(State state) {
        //Elimina las propiedades del estado (que forman el mundo de ese estado)
        //contenidas en la lista de eliminaciones del operador.
		state.properties.RemoveAll(item => _eliminationsList.Contains(item));
	}

    private void Add(State state) {
        //Añade las propiedades del estado (que forman el mundo de ese estado)
        //contenidas en la lista de eliminaciones del operador.
        state.properties.AddRange(_addList);
	}

    //Runs through the operator precondition list to ensure it can be applied.
	public bool isApplicable(State state) {
		foreach(string precondition in _preconditionsList) {
			if (!state.properties.Contains (precondition)) {
				return false;
			}
		}
		return true;
	}


    //Getters for property addition and elimination lists and operator precondition lists.
	public List<string> getAddList() {
		return _addList;
	}

	public List<string> getPreconditionList() {
		return _preconditionsList;
	}

	public List<string> getElminationList() {
		return _eliminationsList;
	}
}