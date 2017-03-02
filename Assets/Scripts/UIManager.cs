﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject gameOverScreen, pauseScreen, gameActiveScreen;

    public void ShowGameOverScreen(bool active=true)
    {
        gameOverScreen.SetActive(active);
    }

    public void ShowGameActiveScreen(bool active=true)
    {
        gameActiveScreen.SetActive(active);
    }

    public void ShowPauseScreen(bool active = true)
    {
        pauseScreen.SetActive(active);
    }
}