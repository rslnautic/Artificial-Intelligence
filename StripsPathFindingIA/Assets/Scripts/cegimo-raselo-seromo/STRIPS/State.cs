using System.Collections.Generic;

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

    public bool Contains(List<string> ptrs){
        foreach (string property in ptrs){
            if (!properties.Contains(property)){
                return false;
            }
        }
        return true;
    }

    public bool Contains(string ptr){
        return properties.Contains(ptr);
    }
}