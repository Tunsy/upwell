using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	
	public void LoadByIndex (int sceneIndex)
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
}
