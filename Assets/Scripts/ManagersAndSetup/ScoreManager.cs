using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private static string level_award_path = "level_award.txt";
    public Dictionary<string, int[]> level_awards = new Dictionary<string, int[]>();
    private Dictionary<string, string> levels_to_unlock = new Dictionary<string, string>();

    public static ScoreManager instance = new ScoreManager();
    public const int MAX_TIME = 999999999;

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
        read_scores();
       //scoreReset();
        
    }

        // Use this for initialization
        void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void scoreReset()
    {
        PlayerPrefs.SetInt("total_stars", 0);
        
        string[] all = { "Level 1-1", "Level 1-2", "Level 1-3", "Level 2-1", "Level 2-2", "Level 2-3", "Level 3-1", "Level 3-2", "Level 3-3" };
        foreach(string name in all)
        {
            PlayerPrefs.SetInt(name + "time", MAX_TIME);
            PlayerPrefs.SetInt(name + "coin", 0);
            PlayerPrefs.SetInt(name + "stars", 0);
        }
    }

   public void read_scores()
    {

        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(level_award_path);
        while ((line = file.ReadLine()) != null)
        {
            string[] line_info = line.Split(':');

            int[] scores = new int[6];
            for (int i = 2; i < line_info.Length; i++)
            {
                scores[i - 2] = int.Parse(line_info[i]);
            }

            level_awards.Add(line_info[0], scores);
            levels_to_unlock.Add(line_info[0], line_info[1]);
            Debug.Log(line_info[0]);
        }

        file.Close();

    }

    public bool meetsReq(string level)
    {
        string unlock = levels_to_unlock[level];
        int stars;
        bool isStar = int.TryParse(unlock, out stars);
        if (isStar)
            return PlayerPrefs.GetInt("total_stars", 0) >= stars;
        return PlayerPrefs.GetInt(unlock + "stars") > 0;
    }
    
    //gets the score needed to achieve a certain number of stars for the given level
    public int StarTimeScore(string level, int stars)
    {
        return level_awards[level][stars - 1];
    }

   

    public int StarCoinScore(string level, int stars = 1)
    {
        return level_awards[level][stars + 2];
    }

    public void setStars(string level) //takes a specific level name, and sets the stars for level and total star count using PlayerPrefs based on the time and coin high score of the game
    {
        if (!isLevel(level))
            return;
        string time_stars = level + "Timestars";
        string coin_stars = level + "Coinstars";
    
        PlayerPrefs.SetInt("total_stars", PlayerPrefs.GetInt("total_stars") - starsForLevel(level));
        
        int t;
        int c; ;
        for (t = 0; t < 3 && level_awards[level][t] >= timeHighScore(level); t++) ;
        for (c = 0; c < 3 && level_awards[level][c + 3] <=  coinHighScore(level); c++) ;
        PlayerPrefs.SetInt(time_stars, t);
        PlayerPrefs.SetInt(coin_stars, c);
        PlayerPrefs.SetInt("total_stars", PlayerPrefs.GetInt("total_stars") + starsForLevel(level));
    }

    public bool isLevel(string level)
    {
        return level_awards.ContainsKey(level);
    }

    //returns the best time and coin score for a specific level name
    public int timeHighScore(string level)
    {
        return PlayerPrefs.GetInt(level + "time",MAX_TIME);

    }

    public int coinHighScore(string level)
    {
        return PlayerPrefs.GetInt(level + "coin",0);
    }

    public int coinStars(string level)
    {
        return PlayerPrefs.GetInt(level + "Coinstars");
    }

    public int timeStars(string level)
    {
        return PlayerPrefs.GetInt(level + "Timestars");
    }

    public int starsForLevel(string level)
    {
        return timeStars(level) + coinStars(level);
    }

    public int totalStars()
    {
        return PlayerPrefs.GetInt("total_stars");
    }
}
