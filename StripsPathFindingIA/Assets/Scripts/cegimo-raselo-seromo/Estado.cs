using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Estado
    {
		public Vector2 Position { get; set; }
		public GenerateMap Map { get; set; }
		public Move.MoveDirection Accion { get; set; }

		public Estado(Vector2 _currentPosition, GenerateMap _map, Move.MoveDirection _accion)
        {
			Position = _currentPosition;
			Map = _map;
            Accion = _accion;
        }

        public bool EsMeta()
        {
			if (isPositionInMap(Position)) {
                GenerateMap.TileType currentTile = Map.GetTile((int)Position.y, (int)Position.x);
                return currentTile == GenerateMap.TileType.Goal;
			} else {
				return false;
			}
        }

        private bool isPositionInMap(Vector2 position) {
            try
            {
                if ((position.x >= 0 && position.x < Map.cols) && (position.y >= 0 && position.y < Map.rows) 
                    && Map.GetTile((int) position.y, (int) position.x) != GenerateMap.TileType.Wall)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("Error a la hora de calcular posición");
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Estado;
			return other != null && (Position == other.Position /*&& Map == other.Map && Accion == other.Accion*/);
            
        }

		public bool CanMoveToDirection(Move.MoveDirection moveDirection)
		{
			Vector2 nextPosition = Position;
			switch (moveDirection)
			{
			case Move.MoveDirection.Up:
				nextPosition += Vector2.up;
				return isPositionInMap(nextPosition);
			case Move.MoveDirection.Down:
				nextPosition += Vector2.down;
				return isPositionInMap(nextPosition);
			case Move.MoveDirection.Left:
				nextPosition += Vector2.left;
				return isPositionInMap(nextPosition);
			case Move.MoveDirection.Right:
				nextPosition += Vector2.right;
				return isPositionInMap(nextPosition);
			default:
				return false;
			}
		}
        

        public List<Estado> Expandir()
        {
            List<Estado> estadosExpandidos = new List<Estado>();
            Estado estado;

			// Move UP
			estado = new Estado(Position + Vector2.up, Map, Move.MoveDirection.Up);
			if (!estado.Equals (this) && CanMoveToDirection (estado.Accion)) {
				estadosExpandidos.Add (estado);
			}
			// Move Down
			estado = new Estado(Position + Vector2.down, Map, Move.MoveDirection.Down);
			if (!estado.Equals (this) && CanMoveToDirection (estado.Accion)) {
				estadosExpandidos.Add (estado);
			}
			// Move Left
			estado = new Estado(Position + Vector2.left, Map, Move.MoveDirection.Left);
			if (!estado.Equals (this) && CanMoveToDirection (estado.Accion)) {
				estadosExpandidos.Add (estado);
			}
			// Move Right
			estado = new Estado(Position + Vector2.right, Map, Move.MoveDirection.Right);
			if (!estado.Equals (this) && CanMoveToDirection (estado.Accion)) {
				estadosExpandidos.Add (estado);
			}

			return estadosExpandidos;
        }
    }
}
