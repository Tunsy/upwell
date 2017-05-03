using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {
   

        
     /* Each line of line_award.txt should be in format:
      name of level:the level which you need to achieve a minumim score of in order to unlock this level:Minumum score needed to unlock the next level:silver score tier:gold score tier
     
     
     Example:
       . . .
     lvl1:lvl0:15:20:30
      lvl2:lvl1:10:20:30 means that in order to access the lvl 2 button, the player's highscore on lvl1 has to be >= than 15 */
     
    // Use this for initialization
    void Start () {


        Dictionary<string, int[]> level_awards = ScoreManager.instance.level_awards;
        
        
        foreach (Transform child in transform)
        {
            if (level_awards.ContainsKey(child.name) && ScoreManager.instance.meetsReq(child.name)){
                child.gameObject.SetActive(true);
                child.GetComponentInChildren<Text>().text = child.name + "player stars: " + ScoreManager.instance.starsForLevel(child.name);
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

    
    
}
