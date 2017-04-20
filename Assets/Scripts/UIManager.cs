using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject gameOverScreen, gameActiveScreen, LvlSummary;

    public void ShowGameOverScreen(bool active=true)
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(active);
    }

    public void ShowGameActiveScreen(bool active=true)
    {
        gameActiveScreen.SetActive(active);
    }

    public void ShowLVLSummary (bool active = true)
    {
        
        Time.timeScale = 0;
        LvlSummary.SetActive(active);
    }
}
