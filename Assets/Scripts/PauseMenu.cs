using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseMenuCanvas;
    private bool x;
    void Start()
    {
        Time.timeScale = 1;     
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            x = !x;
            PauseMenuCanvas.SetActive(x);
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
