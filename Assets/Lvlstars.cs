using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvlstars : MonoBehaviour {

    private int coins;
    public Text text;
    public GameObject manager;
    public string level;

    void Start()
    {
        text = this.GetComponent<Text>();
        //Scene scene = SceneManager.GetActiveScene();
       // level = scene.name;
    }

    void Update()
    {
        coins = manager.GetComponent<ScoreManager>().starsForLevel(level);
        text.text = "" + coins;
    }
}
