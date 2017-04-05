using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

    public static int score;
    public Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        score = GameManager.instance.getcoinamount();
        text.text = "" + score;

        if(score == 100)
        {
            score = 0;
        }
    }
}
