using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public int score;
    public Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        score = GameManager.instance.getPlayerScore();
        text.text = "" + score;
    }
}
