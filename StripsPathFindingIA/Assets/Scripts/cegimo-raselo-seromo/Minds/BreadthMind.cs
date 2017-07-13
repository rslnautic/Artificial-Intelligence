using UnityEngine;
using Assets.Scripts;

public class BreadthMind : IMind {
	
	private BusquedaAmplitud _busqueda;
	private Nodo _resultado = null;
    private Vector2? _lastEndPos = null;

    private Move move;

    public BreadthMind()
    {
        _busqueda = new BusquedaAmplitud();
    }

	public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos, GenerateMap map){
		if(_resultado == null || _lastEndPos != endPos){
            if(Nodo.mapNodeStatus == null){
                Nodo.mapNodeStatus = new byte[map.cols,map.rows];
            }
            _resultado = _busqueda.Buscar(new Estado(currentPos, map, Move.MoveDirection.Right), new Estado(endPos, map, Move.MoveDirection.Right));
            _lastEndPos = endPos;
        }else{
            _resultado = _resultado.Padre;
        }
        return _resultado.Estado.Accion;
    }
}
