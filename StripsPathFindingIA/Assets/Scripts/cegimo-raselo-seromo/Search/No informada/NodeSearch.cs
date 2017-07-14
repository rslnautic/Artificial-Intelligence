using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class NodeSearch : Node<NodeSearch>
    {
        /*public new NodeSearch Padre
        {
            get
            {
                return (NodeSearch)Padre;
            }
        }*/

        public override NodeSearch Padre { get; set; }

        public NodeSearch(Estado e, NodeSearch padre) : base(e, padre)
        {

        }

        public override List<NodeSearch> Expandir(){
            List<Estado> estadosDerivados = Estado.Expandir();
            //Eliminamos bucles simples
            List<NodeSearch> nodosExpandidos = new List<NodeSearch>();
            foreach (var estado in estadosDerivados){
                if (Padre != null){
                    if (!Padre.Estado.Equals(estado)){
                        if(BusquedaNoInformada.MapNodeStatus[(int) estado.Position.x, (int) estado.Position.y] == 0){
                            nodosExpandidos.Add(new NodeSearch(estado, this));
                            BusquedaNoInformada.MapNodeStatus[(int)estado.Position.x, (int)estado.Position.y] = 1;
                        }
                    }
                }
                else{
                    nodosExpandidos.Add(new NodeSearch(estado, this));
                }
            }
            return nodosExpandidos;
        }

        public override string ToString()
        {
			var resultado = string.Format(" E: ({0}) despues de {1}\n", Estado.Position, Estado.Accion);
            if (Padre != null)
            {
                resultado = Padre + resultado;
            }
            return resultado;
        }
    }
}
