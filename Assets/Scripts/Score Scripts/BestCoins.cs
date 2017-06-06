using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestCoins : MonoBehaviour {

    private int coins;
    public Text text;
    public GameObject manager;
    public string level;

    void Start()
    {
        text = this.GetComponent<Text>();
        manager = FindObjectOfType<ScoreManager>().gameObject;
        //Scene scene = SceneManager.GetActiveScene();
        //level = scene.name;
        //level = SceneManager.GetActiveScene().name;

    }

    void Update()
    {
        coins = manager.GetComponent<ScoreManager>().coinHighScore(level);
        text.text = "Best Coins: " + coins;
    }
}
