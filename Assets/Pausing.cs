using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour {

    public GameObject Screen1;
    public GameObject Screen2;

    void Update()
    {
        if (Screen1.activeSelf == true)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
