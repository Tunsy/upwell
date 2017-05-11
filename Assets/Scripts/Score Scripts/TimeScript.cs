using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public int score;
    public Text text;
    public int x;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        score = (int) GameManager.instance.timeElapsed();
        if (x == 1)
        {
            text.text = "" + score;
        }
        else
        {
            text.text = "Time:" + score;
        }
    }
}
