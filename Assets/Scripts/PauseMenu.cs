using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseScreen;
    private bool x;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            x = !x;
            PauseScreen.SetActive(x);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

}