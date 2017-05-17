using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestTimeScript : MonoBehaviour {

    private int time;
    public Text text;
    public GameObject manager;
    public string level;

    void Start()
    {
        text = this.GetComponent<Text>();
        //Scene scene = SceneManager.GetActiveScene();
        //level = scene.name;
        Debug.Log(level);//scene.name);
    }

    void Update()
    {
        time = ScoreManager.instance.timeHighScore(level);
        text.text = "Best: " + time;
    }
}
