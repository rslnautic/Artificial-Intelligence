using UnityEngine;
using Assets.Scripts;

public class BreadthMind : IMind {
	
	private BusquedaAmplitud _busqueda;
	private Nodo _resultado = null;

    private Move move;

    public BreadthMind()
    {
        _busqueda = new BusquedaAmplitud();
    }

	public Move.MoveDirection GetNextMove(Vector2 currentPos, GenerateMap map){
		if(_resultado == null){
            // Initialize the matrix to 0 if it isn´t allready
            // (this matrix represents the map and ensures the quality of the breadth algorithm. It maps the allready accessed nodes with a 1)
            if(Nodo.mapNodeStatus == null){
                Nodo.mapNodeStatus = new byte[map.cols,map.rows];
            }
            _resultado = _busqueda.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right));
            return _resultado.Estado.Accion;
        }else{
            _resultado = _resultado.Padre;
            return _resultado.Estado.Accion;
        }
	}
}
