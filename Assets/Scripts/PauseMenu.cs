using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseScreen;
    private bool x;
    private int y = 3;      //timer
    public Text Text;

    void Update()
    {
        Text = this.GetComponent<Text>();
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
                while(y > 0)
                {

                    Debug.Log("" + y);
                    y -= 1;
                }
                y = 3;
                Time.timeScale = 1;
            }
        }
    }

}