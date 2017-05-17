using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public static GameManager instance = new GameManager();

    //member variables
    public float time = START_TIME;
    private float score = 1;
    private int coin = 0;
    private int lives = DEFAULT_LIVES;
    private GameObject player;
    private UIManager uiManager;
    private int current_level = START_LEVEL;
    private bool is_alive = DEFAULT_ALIVE_STATE;
    private float time_interval = STARTING_INTERVAL;
    private int coin_counter = 0;
    private int deathCount;


    private Dictionary<string, int[]> level_awards = new Dictionary<string, int[]>();
    //change this to name of the scene you are running on currently, 
    public string mainscene = "gametest";
    public GameObject canvas;


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
        coin_counter = 0;
        lives = 0;
        is_alive = DEFAULT_ALIVE_STATE;
        time_interval = STARTING_INTERVAL;
        Time.timeScale = 1;
    }

    public void GrabUI(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (gameRunning())
        {
            if (!isAlive())
            {
                uiManager.ShowRetryScreen();
                if (Input.anyKeyDown)
                {
                    GameManager.instance.InitializeValues();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
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
        return time;
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

    public void giveDash()
    {
        PlayerPrefs.SetInt("dash", 1);
    }

    public bool canDash()
    {
        return PlayerPrefs.GetInt("dash") == 1;
    }

    public void removeDash()
    {
        PlayerPrefs.SetInt("dash", 0);
    }


    public bool gameRunning()
    {
        //return SceneManager.GetActiveScene().name == mainscene;
        //gameActiveScreen.SetActive(true);
        if (SceneManager.GetActiveScene().name.Contains("Level"))
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



    public void updatePickupScore(int points)
    {
        //coins += 1;

        /*if (coins >= 100)
        {
            lives++;
            coins -= 100;
        } */

        coin_counter += points * PICKUP_SCORE_COEFFICIENT;
        //delete later

    }


    public int getcoinamount()
    {
        return coin_counter;
    }

    public int getLives()
    {
        return lives;
    }

    //void methods and others, to be called from other scripts
    public void endGame()
    {
        GameOverScreen();
    }

    public void UpdateTime()
    {
        if (isAlive() && gameRunning())
        {
            time += Time.deltaTime;
        }
    }

    public void resetTimer()
    {
        time = 0;
    }

    public void killPlayer()
    {
        deathCount++;
        is_alive = false;
    }

    public float GetDeathCount()
    {
        return deathCount;
    }

    public void SetDeathCount(int death)
    {
        deathCount = death;
    }

    public void GameOverScreen()
    {
        uiManager.ShowGameOverScreen(true);
        uiManager.ShowGameActiveScreen(false);
    }

    public void resumeMain()
    {
        SceneManager.LoadScene(mainscene);
    }

    public void setHighScores()
    {


        Debug.Log(time);
        string timeKey = SceneManager.GetActiveScene().name + "time";
        if (time < PlayerPrefs.GetInt(timeKey))
            PlayerPrefs.SetInt(timeKey, (int)time);
        string coinKey = SceneManager.GetActiveScene().name + "coin";
        if (coin_counter > PlayerPrefs.GetInt(coinKey))
            PlayerPrefs.SetInt(coinKey, coin_counter);


        Debug.Log(time);
    }

    public void setStars()
    {
        ScoreManager.instance.setStars(SceneManager.GetActiveScene().name);
    }
}
