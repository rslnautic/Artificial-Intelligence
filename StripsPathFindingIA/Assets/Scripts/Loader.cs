using UnityEngine;
using System.Collections;

namespace Completed
{
    public class Loader : MonoBehaviour
    {
        public GameObject gameManager;          //GameManager prefab to instantiate.
        public bool Planner=false;
        public int seed = 2016;
        void Awake()
        {
            //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
            if (GameManager.instance == null)
            {
                //Instantiate gameManager prefab
                var obj = Instantiate(gameManager) as GameObject;
                obj.name = "GameManager";
                var manager=obj.GetComponent<GameManager>();
                manager.ForPlanner = Planner;
                manager.seed = seed;
                manager.InitGame();
            }


        }
    }
}