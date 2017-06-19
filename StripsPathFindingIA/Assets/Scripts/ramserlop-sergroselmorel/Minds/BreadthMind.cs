using System.Collections;
using System.Collections.Generic;
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

	public Move.MoveDirection GetNextMove(Vector2 currentPos, GenerateMap map)
	{
		if(_resultado == null)
        {   
            if(Nodo.mapNodeStatus == null)
            {
                Nodo.mapNodeStatus = new byte[map.cols,map.rows];
            }
            _resultado = _busqueda.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right));
            return _resultado.Estado.Accion;
        } else
        {
            _resultado = _resultado.Padre;
            return _resultado.Estado.Accion;
        }
	}
}
