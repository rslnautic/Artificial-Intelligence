using UnityEngine;
using Assets.Scripts;

public class DepthMind : IMind{
    private BusquedaProfundidad _busqueda;
    private NodoProfundidad _resultado = null;
    private Move move;

    public DepthMind(){
        _busqueda = new BusquedaProfundidad();
    }

    public Move.MoveDirection GetNextMove(Vector2 currentPos, Vector2 endPos, GenerateMap map){
        if (_resultado == null){
            // Initialize the matrix to 0 if it isn´t allready
            // (this matrix represents the map and ensures the quality of the breadth algorithm. It maps the allready accessed nodes with a 1)
            if (Nodo.mapNodeStatus == null){
                Nodo.mapNodeStatus = new byte[map.cols, map.rows];
            }
            _resultado = _busqueda.Buscar(new EstadoProfundidad(currentPos, map, Move.MoveDirection.Right));
            return _resultado.Estado.Accion;
        }
        else{
            _resultado = _resultado.Padre;
            return _resultado.Estado.Accion;
        }
    }
}
