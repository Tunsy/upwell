using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public static GameManager instance = new GameManager();

    //copied this thing from forum
    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new GameManager();
    //        }

    //        return instance;
    //    }
    //}

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(SceneManager.GetActiveScene().name);
       if(gameRunning())
        {
            if (!isAlive())
            {
                endGame();
            }
            score += Time.deltaTime * TIME_SCORE_COEFFICIENT;
            update_time();
            //Debug.Log(time);
            
        }

       
        

      



    }

    //member variables
    private float time = START_TIME;
    private float score = 0;
    private GameObject player;
    private int current_level = START_LEVEL;
    private bool is_alive = DEFAULT_ALIVE_STATE;
    private float time_interval = STARTING_INTERVAL;

    //change this to name of the scene you are running on currently, 
    public string mainscene = "maintest";

   
    //static variables
    private static float START_TIME = 0;
    private static int START_LEVEL = 0;
    private static bool DEFAULT_ALIVE_STATE = true;
    private static float STARTING_INTERVAL = 1;
    private static int TIME_SCORE_COEFFICIENT = 1;
    private static int PICKUP_SCORE_COEFFICIENT = 4;
    


    //return methods

    public bool isAlive()
    {
        return is_alive;
    }
    /*
    public float timeElapsed()
    {
        return this.time;
    }

   
    public int currentLevel()
    {
        return this.current_level;
    }
    */

    public bool gameRunning()
    {
        return SceneManager.GetActiveScene().name == mainscene;
    }
    public int getPlayerScore()
    {
        return (int)score;
    }

    public void updatePickupScore(int points)
    {
        score += points * PICKUP_SCORE_COEFFICIENT;
    }
    //void methods and others, to be called from other scripts
    public void endGame()
    {
        Debug.Log("game is over");
        resetTimer();
        SceneManager.LoadScene("TitleScreen");
    }
    public void update_time()
    {
        time += Time.deltaTime;
    }

   /* public void updateLevel()
    {
        current_level += 1;
        Debug.Log("starting level" + current_level.ToString());
    }

*/
    public void resetTimer()
    {
        time = 0;
    } 
/*
    public void setNextInterval()
    {
        time_interval *= 2;
    } */

    public void killPlayer()
    {
        is_alive = false;
    }

    public void pauseScene()
    {
        SceneManager.LoadScene("PauseMenu");
        
    }

    public void resumeMain()
    {
        SceneManager.LoadScene(mainscene);
    }
}
