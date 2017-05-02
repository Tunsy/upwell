using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BestTimeScript : MonoBehaviour {

    private int time;
    public Text text;
    public GameObject manager;
    string level;

    void Start()
    {
        text = this.GetComponent<Text>();
        Scene scene = SceneManager.GetActiveScene();
        level = scene.name;
    }

    void Update()
    {
        time = manager.GetComponent<ScoreManager>().timeHighScore(level);
        text.text = "Best Time: " + time;
    }
}
