using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvlstars : MonoBehaviour {

    private int coins;
    public Text text;
    public GameObject manager;
    public bool totaltime;
    private string[] array;
    private bool initial;
    public string lvl;
    public bool totalscore;

    void Start()
    {
        text = this.GetComponent<Text>();
        //Scene scene = SceneManager.GetActiveScene();
        // level = scene.name;
        array = new string[] { "Level 1-1", "Level 1-2", "Level 1-3", "Level 2-1", "Level 2-2", "Level 2-3", "Level 3-1", "Level 3-2", "Level 3-3" };
        initial = false;
    }

    void Update()
    {
        if (totalscore == true)
        {
            if (totaltime == false)
            {
                if (initial == false)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        coins += manager.GetComponent<ScoreManager>().coinStars(array[i]);
                    }
                    initial = true;
                }
                text.text = "" + coins;
            }
            else
            {
                if (initial == false)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        coins += manager.GetComponent<ScoreManager>().timeStars(array[i]);
                    }
                    initial = true;
                }
                text.text = "" + coins;
            }
        }
        else
        {
            if (initial == false)
            {
                if (totaltime == true)
                {
                    coins += manager.GetComponent<ScoreManager>().timeStars(lvl);
                    text.text = "" + coins;
                }
                else
                {
                    coins += manager.GetComponent<ScoreManager>().coinStars(lvl);
                    text.text = "" + coins;
                }
                initial = true;
            }
        }
    }
}
