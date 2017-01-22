using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
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
				return Map.GetTile (Position.x, Position.y) == GenerateMap.TileType.Goal;
			} else {
				return false;
			}
        }

		private bool isPositionInMap(Vector2 position) {
			if ((position.x >= 0 && position.x < Map.cols) && (position.y >= 0 && position.y < Map.rows)) {
				return true;
			} else {
				return false;
			}
		}

        public override bool Equals(object obj)
        {
            var other = obj as Estado;
			return other != null && (Position == other.Position && Map == other.Map && Accion == other.Accion);
            
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
			estado = new Estado(Position + Vector2.up, Map, Accion);
			if (!estado.Equals (this) && CanMoveToDirection (Move.MoveDirection.Up)) {
				estadosExpandidos.Add (estado);
			}
			// Move Down
			estado = new Estado(Position + Vector2.down, Map, Accion);
			if (!estado.Equals (this) && CanMoveToDirection (Move.MoveDirection.Down)) {
				estadosExpandidos.Add (estado);
			}
			// Move Left
			estado = new Estado(Position + Vector2.left, Map, Accion);
			if (!estado.Equals (this) && CanMoveToDirection (Move.MoveDirection.Left)) {
				estadosExpandidos.Add (estado);
			}
			// Move Right
			estado = new Estado(Position + Vector2.right, Map, Accion);
			if (!estado.Equals (this) && CanMoveToDirection (Move.MoveDirection.Right)) {
				estadosExpandidos.Add (estado);
			}

			return estadosExpandidos;
        }
    }
}
