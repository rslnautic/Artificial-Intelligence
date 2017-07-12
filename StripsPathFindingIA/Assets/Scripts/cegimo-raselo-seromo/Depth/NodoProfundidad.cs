using System.Collections.Generic;

namespace Assets.Scripts{
    public class NodoProfundidad{
        public static byte[,] mapNodeStatus = null;
        public NodoProfundidad Padre { get; set; }
        public EstadoProfundidad Estado { get; set; }
        public NodoProfundidad(EstadoProfundidad e, NodoProfundidad padre){
            Padre = padre;
            Estado = e;
        }

        public virtual List<NodoProfundidad> Expandir(){
            EstadoProfundidad estado = Estado.Expandir();
            //Eliminamos bucles simples
            List<NodoProfundidad> nodosExpandidos = new List<NodoProfundidad>();
            if (Padre != null){
                if (!Padre.Estado.Equals(estado)){
                    if (mapNodeStatus[(int)estado.Position.x, (int)estado.Position.y] == 0){
                        nodosExpandidos.Add(new NodoProfundidad(estado, this));
                        mapNodeStatus[(int)estado.Position.x, (int)estado.Position.y] = 1;
                    }
                }
            }else{
                nodosExpandidos.Add(new NodoProfundidad(estado, this));
                }
            return nodosExpandidos;
        }

        public override string ToString(){
            var resultado = string.Format(" E: ({0}) despues de {1}\n", Estado.Position, Estado.Accion);
            if (Padre != null){
                resultado = Padre + resultado;
            }
            return resultado;
        }
    }
}