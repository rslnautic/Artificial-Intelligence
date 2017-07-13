using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class BusquedaAmplitud{
        public Queue<Nodo> Abiertos { get; set; }
        public static Vector2 finalPos;
        public BusquedaAmplitud(){
            Abiertos = new Queue<Nodo>();
        }

        public Nodo Buscar(Estado inicio, Estado final)
        {
            inicio.Accion = Move.MoveDirection.Right;
            finalPos = final.Position;
            Nodo inicial = new Nodo(inicio, null);

            Abiertos.Enqueue(inicial);
            while (Abiertos.Count>0){
                Nodo actual = Abiertos.Dequeue();
                if (EsMeta(actual)){
                    return actual;
                }
                List<Nodo> actualExpandido = actual.Expandir();
                foreach (var nodo in actualExpandido){
                    Abiertos.Enqueue(nodo);
                }
            }
            return null;
        }

        public bool EsMeta(Nodo actual)
        {   
            if(finalPos == new Vector2(actual.Estado.Map.cols-1, actual.Estado.Map.rows-1))
            {
                return actual.Estado.EsMeta();
            } else
            {
                return actual.Estado.Position == finalPos;
            }
            
        }
    }
}
