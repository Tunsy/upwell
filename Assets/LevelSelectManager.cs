using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {
    private static string level_award_path = "level_award.txt";
    private Dictionary<string, int[]> level_awards = new Dictionary<string, int[]>();

    // Use this for initialization
    void Start () {
        read_scores();
        foreach (Transform child in transform)
        {
            if (level_awards.ContainsKey(child.name)){
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
            for (int i = 1; i < line_info.Length; i++)
            {
                scores[i - 1] = int.Parse(line_info[i]);
            }
            level_awards.Add(line_info[0], scores);

        }

        file.Close();

    }
}
