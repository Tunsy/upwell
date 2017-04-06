﻿using System.Collections;
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

    //member variables
    private float time = START_TIME;
    private float score = 0;
    private int coin = 0;
    private int lives = DEFAULT_LIVES;
    private GameObject player;
    private UIManager uiManager;
    private int current_level = START_LEVEL;
    private bool is_alive = DEFAULT_ALIVE_STATE;
    private float time_interval = STARTING_INTERVAL;

    //change this to name of the scene you are running on currently, 
    public string mainscene = "gametest";
    public GameObject canvas;
    //public GameObject gameOverScreen;
    //public GameObject pauseScreen;
    //public GameObject gameActiveScreen;


    //static variables
    private static float START_TIME = 0;
    private static int START_LEVEL = 1;
    private static bool DEFAULT_ALIVE_STATE = true;
    private static int DEFAULT_LIVES = 3;
    private static float STARTING_INTERVAL = 1;
    private static int TIME_SCORE_COEFFICIENT = 1;
    private static int PICKUP_SCORE_COEFFICIENT = 4;

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

    private void Start()
    {
        //canvas = GameObject.Find("Canvas");
        //GrabUI();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        SceneManager.sceneLoaded += GrabUI;
    }

    public void InitializeValues()
    {
        time = START_TIME;
        score = 0;
        coin = 0;
        lives = DEFAULT_LIVES;
        is_alive = DEFAULT_ALIVE_STATE;
        time_interval = STARTING_INTERVAL;
        Time.timeScale = 1;
    }

    public void GrabUI(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //gameOverScreen = GameObject.Find("GameOverScreen");
        //gameActiveScreen = GameObject.Find("Gamescreen");
        //gameOverScreen.SetActive(false);
        //gameActiveScreen.SetActive(true);
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
                Debug.Log("Checking");
            }
            else
            {
                score += Time.deltaTime * TIME_SCORE_COEFFICIENT;
                update_time();
               /* int lvl = updateCurrentLevel();
                if(lvl != current_level)
                {
                    current_level = lvl;
                    
                }*/
            }
        }

    }


    


    //return methods

    public bool isAlive()
    {
        return is_alive;
    }
    
    public float timeElapsed()
    {
        return this.time;
    }

   
     public void updateCurrentLevel()
    {
        //int  level =  (int)Mathf.Log((time + 1) * 10);
        Debug.Log("level");
        current_level += 1;
    }
    
    public int getLevel()
    {
        return current_level;
    }

    public bool gameRunning()
    {
        //return SceneManager.GetActiveScene().name == mainscene;
        //gameActiveScreen.SetActive(true);
        if (SceneManager.GetActiveScene().name.Contains("level"))
        {
            uiManager.ShowGameActiveScreen(true);
            return true;
        }
        else
        {
            return false;
        }
    }
    public int getPlayerScore()
    {
        return (int)score;
    }

    public void updatePickupScore(int points)
    {
        coin += 1;

        if (coin >= 100)
        {
            lives++;
            coin -= 100;
        }

        score += points * PICKUP_SCORE_COEFFICIENT;
    }

    public int getcoinamount()
    {
        return coin;
    }

    public int getLives()
    {
        return lives;
    }

    //void methods and others, to be called from other scripts
    public void endGame()
    {
        Debug.Log("game is over");
        //resetTimer();
        GameOverScreen();
        // SceneManager.LoadScene("TitleScreen");
    }
    public void update_time()
    {
        if (isAlive())
        {
            time += Time.deltaTime;
        }
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
        Debug.Log(lives);
        if (lives > 0)
        {
            lives--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
            is_alive = false;
    }

    public void GameOverScreen()
    {
        uiManager.ShowGameOverScreen(true);
        uiManager.ShowGameActiveScreen(false);
        //gameOverScreen.SetActive(true);
        //gameActiveScreen.SetActive(false);
    }

    public void resumeMain()
    {
        SceneManager.LoadScene(mainscene);
    }
}
