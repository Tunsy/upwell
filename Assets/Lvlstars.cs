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
    public bool game;
    public Image star1;
    public Image star2;
    public Image star3;

    void Start()
    {
        text = this.GetComponent<Text>();
        //Scene scene = SceneManager.GetActiveScene();
        // level = scene.name;
        if(game == true)
        {
            lvl = SceneManager.GetActiveScene().name;
            /*var tempColor = star1.color;
            tempColor.a = 0f;
            star1.color = tempColor;
            star2.color = tempColor;
            star3.color = tempColor;*/
            star1.CrossFadeAlpha(0f, 0.1f, true);
            star2.CrossFadeAlpha(0f, 0.1f, true);
            star3.CrossFadeAlpha(0f, 0.1f, true);
        }
        manager = GameObject.Find("ScoreManager");
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
                        //Debug.Log("time" + array[i] + manager.GetComponent<ScoreManager>().StarTimeScore(array[i], 3));
                        //Debug.Log("coins" + array[i] + manager.GetComponent<ScoreManager>().StarCoinScore(array[i], 3));
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
                    if (game == false)
                    {
                        text.text = "" + coins;
                    }
                }
                else
                {
                    coins += manager.GetComponent<ScoreManager>().coinStars(lvl);
                    if (game == false)
                    {
                        text.text = "" + coins;
                    }
                }
                if (game == true)
                {
                    if (coins >= 1)
                    {
                        star1.CrossFadeAlpha(1f, 3.0f, true);
                        if (coins >= 2)
                        {
                            star2.CrossFadeAlpha(1f, 4.0f, true);
                            if (coins == 3)
                            {
                                star3.CrossFadeAlpha(1f, 5.0f, true);
                            }
                        }
                    }
                }
                initial = true;
            }
        }
    }
}
