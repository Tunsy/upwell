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
        //level = SceneManager.GetActiveScene().name;
        Debug.Log(level);//scene.name);
        manager = GameObject.Find("ScoreManager");
    }

    void Update()
    {

        time = ScoreManager.instance.timeHighScore(level);
        if (time > 99999)
        {
            text.text = "Best Time: 0";
        }
        else
        {
            text.text = "Best Time: " + time;
        }
    }
}
