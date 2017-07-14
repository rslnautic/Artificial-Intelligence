using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    abstract public class Node<T>
    {
        public abstract T Padre { get; set; }
        public Estado Estado { get; set; }

        public Node(Estado e, T padre)
        {
            Padre = padre;
            Estado = e;
        }

        abstract public List<T> Expandir();
    }
}
