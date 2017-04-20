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
    private int coin_counter = 0;
    private int end_level_score = 0;
    private Dictionary<string, int[]> level_awards;
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
    private static string level_award_path = "level_award.txt";

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

    private void read_scores()
    {
        int counter = 0;
        string line;
        System.IO.StreamReader file =
          new System.IO.StreamReader(level_award_path);
        while ((line = file.ReadLine()) != null)
        {
            string[] line_info = line.Split(':');
            int[] scores = new int[4];
            for (int i = 1; i < line_info.Length; i++)
            {
                scores[i - 1] = int.Parse(line_info[i]);
            }
            level_awards.Add(line_info[0], scores);
            counter++;
        }

        file.Close();
        Debug.Log(level_awards);
    }
    private void Start()
    {
        //canvas = GameObject.Find("Canvas");
        //GrabUI();

        read_scores();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        SceneManager.sceneLoaded += GrabUI;
    }

    public void InitializeValues()
    {
        
        time = START_TIME;
        score = 0;
        coin_counter = 0;
        lives = 0;
        is_alive = DEFAULT_ALIVE_STATE;
        time_interval = STARTING_INTERVAL;
        Time.timeScale = 1;
        end_level_score = 0;
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
               // score += Time.deltaTime * TIME_SCORE_COEFFICIENT;
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
        return coin_counter;
    }

    public int endLevelScore()
    {
        return (int)(coin_counter + TIME_SCORE_COEFFICIENT / time);
    }

   

    public void updatePickupScore(int points)
    {
        //coins += 1;

        /*if (coins >= 100)
        {
            lives++;
            coins -= 100;
        } */

        coin_counter += points * PICKUP_SCORE_COEFFICIENT;
    }

    public int coinScore()
    {
        return coin_counter;
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
        InitializeValues();
        
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
