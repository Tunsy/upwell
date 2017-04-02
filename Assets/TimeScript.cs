using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public int score;
    public Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        score = (int) GameManager.instance.timeElapsed();
        text.text = "" + score;
    }
}
