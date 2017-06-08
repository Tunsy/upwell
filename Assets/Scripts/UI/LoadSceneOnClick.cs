using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public AudioClip hoverSound;
    public AudioClip enterSound;


    public void LoadByIndex(int sceneIndex)
    {
        GameManager.instance.InitializeValues();
        GameManager.instance.SetDeathCount(0);
        SceneManager.LoadScene(sceneIndex);
    }

    public void RetryLevel()
    {
        GameManager.instance.InitializeValues();
        GameManager.instance.SetDeathCount(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        GameManager.instance.InitializeValues();
        GameManager.instance.SetDeathCount(0);
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainLevel()
    {
        GameManager.instance.InitializeValues();
        GameManager.instance.SetDeathCount(0);
        SceneManager.LoadScene("Level 1-1");
    }

    public void LoadLevelSelect()
    {
        GameManager.instance.InitializeValues();
        GameManager.instance.SetDeathCount(0);
        SceneManager.LoadScene("stage_select");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound)
            AudioSource.PlayClipAtPoint(hoverSound, Camera.main.transform.position, .5f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (enterSound)
            AudioSource.PlayClipAtPoint(enterSound, Camera.main.transform.position, .5f);
    }
}