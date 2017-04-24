using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {
    private static string level_award_path = "level_award.txt";
    private Dictionary<string, int[]> level_awards = new Dictionary<string, int[]>();
    private Dictionary<string, string> levels_to_unlock = new Dictionary<string, string>(); 
    
    
     /* Each line of line_award.txt should be in format:
      name of level:the level which you need to achieve a minumim score of in order to unlock this level:Minumum score needed to unlock the next level:silver score tier:gold score tier
     
     
     Example:
       . . .
     lvl1:lvl0:15:20:30
      lvl2:lvl1:10:20:30 means that in order to access the lvl 2 button, the player's highscore on lvl1 has to be >= than 15 */
     
    // Use this for initialization
    void Start () {
        int[] zeroes = { 0, 0, 0 };
        string[] start = { "start", "" };
        level_awards.Add("start", zeroes);
        
        
        read_scores();

        foreach (Transform child in transform)
        {
            if (level_awards.ContainsKey(child.name) && PlayerPrefs.GetInt(levels_to_unlock[child.name]) >= level_awards[levels_to_unlock[child.name]][0]){
                child.gameObject.SetActive(true);
                child.GetComponentInChildren<Text>().text = child.name + "high score " + PlayerPrefs.GetInt(child.name, 0);
                foreach (int score in level_awards[child.name])
                {
                    child.GetComponentInChildren<Text>().text  += " " + score.ToString() + ", ";
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void read_scores()
    {

        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(level_award_path);
        while ((line = file.ReadLine()) != null)
        {
            string[] line_info = line.Split(':');
     
            int[] scores = new int[3];
            for (int i = 2; i < line_info.Length; i++)
            {
                scores[i - 2] = int.Parse(line_info[i]);
            }
            
            level_awards.Add(line_info[0], scores);
            levels_to_unlock.Add(line_info[0], line_info[1]);
        }

        file.Close();

    }
}
