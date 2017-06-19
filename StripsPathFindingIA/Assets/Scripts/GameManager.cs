using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
        public int seed=2016;
        public bool ForPlanner = false;
        public GenerateMap Map { get; set; }
        //Awake is always called before any Start functions
        void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //Get a component reference to the attached BoardManager script
            boardScript = GetComponent<BoardManager>();

            
        }

        //Initializes the game for each level.
        public void InitGame()
        {
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            boardScript.SetupScene(seed, ForPlanner);
            Map = new GenerateMap(boardScript.rows,boardScript.columns,boardScript);
        }

    
    }
