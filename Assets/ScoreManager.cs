using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private static string level_award_path = "level_award.txt";
    public Dictionary<string, int[]> level_awards = new Dictionary<string, int[]>();
    private Dictionary<string, string> levels_to_unlock = new Dictionary<string, string>();

    public static ScoreManager instance = new ScoreManager();


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
        
    }

        // Use this for initialization
        void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
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
    public int StarTimeScore(string level, int stars=1)
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
        string stars = level + "stars";
        PlayerPrefs.SetInt(stars, 0);
        PlayerPrefs.SetInt("total_stars", PlayerPrefs.GetInt("total_stars") - PlayerPrefs.GetInt(stars));
        int t;
        int c; ;
        for (t = 0; t < 3 && level_awards[level][t] <= PlayerPrefs.GetInt(level + "time") ; t++) ;
        for (c = 0; c < 3 && level_awards[level][c + 3] >=  PlayerPrefs.GetInt(level + "coin") ; c++) ;
        PlayerPrefs.SetInt(stars, Mathf.Max(t, c));
        PlayerPrefs.SetInt("total_stars", PlayerPrefs.GetInt("total_stars") + PlayerPrefs.GetInt(stars));
    }

    public bool isLevel(string level)
    {
        return level_awards.ContainsKey(level);
    }

    //returns the best time and coin score for a specific level name
    public int timeHighScore(string level)
    {
        return PlayerPrefs.GetInt(level + "time",0);

    }

    public int coinHighScore(string level)
    {
        return PlayerPrefs.GetInt(level + "coin",0);
    }

    public int starsForLevel(string level)
    {
        return PlayerPrefs.GetInt(level + "stars");
    }

    public int totalStars()
    {
        return PlayerPrefs.GetInt("total_stars");
    }
}
