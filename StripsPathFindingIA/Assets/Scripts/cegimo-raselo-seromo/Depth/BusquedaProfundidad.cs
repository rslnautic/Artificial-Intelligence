using System.Collections.Generic;

namespace Assets.Scripts
{
    public class BusquedaProfundidad
    {
        public Queue<NodoProfundidad> Abiertos { get; set; }
        public BusquedaProfundidad()
        {
            Abiertos = new Queue<NodoProfundidad>();
        }

        public NodoProfundidad Buscar(EstadoProfundidad inicio)
        {
            inicio.Accion = Move.MoveDirection.Right;
            NodoProfundidad inicial = new NodoProfundidad(inicio, null);

            Abiertos.Enqueue(inicial);
            while (Abiertos.Count > 0)
            {
                NodoProfundidad actual = Abiertos.Dequeue();
                if (EsMeta(actual))
                {
                    return actual;
                }
                List<NodoProfundidad> actualExpandido = actual.Expandir();
                foreach (var nodo in actualExpandido)
                {
                    Abiertos.Enqueue(nodo);
                }
            }
            return null;
        }

        public bool EsMeta(NodoProfundidad actual)
        {
            return actual.Estado.EsMeta();
        }
    }
}
