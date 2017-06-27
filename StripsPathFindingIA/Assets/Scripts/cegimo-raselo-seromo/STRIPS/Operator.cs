using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operator {
	
	protected List<Property> _addList;
	protected List<Property> _preconditionsList;
	protected List<Property> _eliminationsList;

	public Operator() {
		_addList = new List<Property> ();
		_preconditionsList = new List<Property> ();
		_eliminationsList = new List<Property> ();
	}

    //Comprueba si el operador contiene la propiedad property en la lista de adiciones.
	public bool Produces(Property property){
		return _addList.Contains(property);
	}

    //Aplica el operador al mundo, cambiando así sus propiedades
    //Añade y elimina propiedades para cambiar su estado
	public State Apply(State state){
		Delete(state);
		Add(state);
        //Devuelve el estado actualizado
		return state;
	}

	public void Delete(State state) {
        //Elimina las propiedades del estado (que forman el mundo de ese estado) contenidas en la lista de eliminaciones del operador.
		state.properties.RemoveAll(item => _eliminationsList.Contains(item));
	}

	public void Add(State state) {
        //Añade las propiedades del estado (que forman el mundo de ese estado) contenidas en la lista de eliminaciones del operador.
        state.properties.AddRange(_addList);
	}

    //Runs through the operator precondition list to ensure it can be applied.
	public bool isApplicable(State state) {
		foreach(Property precondition in _preconditionsList) {
			if (!state.properties.Contains (precondition)) {
				return false;
			}
		}
		return true;
	}


    //Getters for property addition and elimination lists and operator precondition lists.
	public List<Property> getAddList() {
		return _addList;
	}

	public List<Property> getPreconditionList() {
		return _preconditionsList;
	}

	public List<Property> getElminationList() {
		return _eliminationsList;
	}
}