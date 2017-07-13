using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {
	public List<string> properties;

    //Constructor por defecto
	public State() {
		properties = new List<string> ();
	}

    //Constructor con la lista de propiedades
	public State(List<string> listOfProperties) {
		properties = new List<string> (listOfProperties);
	}

    public bool Contains(List<string> ptrs)
    {   if(properties.Count != 0 && ptrs.Count != 0)
        {
            foreach (string property in ptrs)
            {
                if (!properties.Contains(property))
                {
                    return false;
                }
            }
            return true;
        } 
        return false;
    }

    public bool Contains(string ptr)
    {
        return properties.Contains(ptr);
    }
}