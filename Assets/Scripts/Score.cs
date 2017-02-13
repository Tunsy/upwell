using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score;

    void Start ()
    {
        score = 0;
    }

	void Update ()
    {
        /*var script = GameObject.Find("GameManagerLoader").GetComponent<GameManager>();
        score = script.getPlayerScore();*/
        score += 1;
        if(GameObject.Find("Scoretotal") == true)
        {
            Text txt = GameObject.Find("Scoretotal").GetComponent<Text>();
            txt.text = "Score: " + score;
            Destroy(this);
        }
    }

}
