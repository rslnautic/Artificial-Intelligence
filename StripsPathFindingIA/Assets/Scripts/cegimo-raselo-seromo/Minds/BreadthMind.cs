using UnityEngine;
using Assets.Scripts;

public class BreadthMind : IMind {

    private static BreadthMind instance = null;
	private BusquedaAmplitud _busqueda;
	private NodeSearch _resultado = null;
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
		if(_resultado == null || _lastEndPos != endPos){
            _resultado = _busqueda.Buscar(currentPos, endPos);
            _lastEndPos = endPos;
        }else{
            if(_resultado.Padre != null)
            {
                _resultado = _resultado.Padre;
            } else
            {
                return Move.MoveDirection.None;
            }
        }
        return _resultado.Estado.Accion;
    }
}
