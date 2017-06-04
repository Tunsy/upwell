using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Totalstars : MonoBehaviour {

    private int coins;
    public Text text;
    public GameObject manager;

    void Start()
    {
        text = this.GetComponent<Text>();
        //Scene scene = SceneManager.GetActiveScene();
        // level = scene.name;
    }

    void Update()
    {
        coins = manager.GetComponent<ScoreManager>().totalStars();
        text.text = "Total: " + coins;
    }
}
