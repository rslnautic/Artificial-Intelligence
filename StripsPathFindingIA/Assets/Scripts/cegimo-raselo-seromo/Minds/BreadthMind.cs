using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

public class BreadthMind : IMind {

    private static BreadthMind instance = null;
	private BusquedaAmplitud _busqueda;
	private List<NodeSearch> _resultados = null;
    private Vector2? _lastEndPos = null;
    

    public static BreadthMind getBreathMind()
    {
        if(instance != null)
        {
            return instance;
        } else
        {
            return new BreadthMind();
        }
    }

    private BreadthMind()
    {   
        _busqueda = new BusquedaAmplitud();
    }

	public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos){
		if (_resultados == null || _lastEndPos != endPos)
        {
            _resultados = _busqueda.Buscar(currentPos, endPos);
            _resultados.RemoveAt(0);
            _lastEndPos = endPos;
        }
        if (_resultados.Count != 0)
        {
            NodeSearch nextMoveNode = _resultados[0];
            _resultados.RemoveAt(0);
            return nextMoveNode.Estado.Accion;
        }
        else
        {
            return Move.MoveDirection.None;
        }
    }
}
