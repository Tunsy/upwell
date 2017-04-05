using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScriptV2 : MonoBehaviour {

    public int score;
    public Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        score = (int)GameManager.instance.timeElapsed();
        text.text = "Time:" + score;
    }
}
