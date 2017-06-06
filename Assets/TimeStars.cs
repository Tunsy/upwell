using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStars : MonoBehaviour {

    public GameObject manager;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public string level;
    private int stars;

    void Update ()
    {
        stars = manager.GetComponent<ScoreManager>().timeStars(level);
        if(stars >= 1)
        {
            star1.SetActive(true);
            if( stars >= 2)
            {
                star2.SetActive(true);
                if(stars == 3)
                {
                    star3.SetActive(true);
                }
            }
        }
    }
}
