using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

    public int score;
    public Text words;
    public int x = 0;

    void Start()
    {
        words = this.GetComponent<Text>();
    }

    void Update()
    {
        score = (int)GameManager.instance.getcoinamount();
        if (x == 1)
        {
            words.text = "" + score;
        }
        else
        {
            words.text = "Coins:" + score;
        }
    }
}
