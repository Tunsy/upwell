using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	
	public void LoadByIndex (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RetryLevel()
    {
        GameManager.instance.InitializeValues();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        
        GameManager.instance.InitializeValues();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainLevel()
    {
        GameManager.instance.InitializeValues();
        SceneManager.LoadScene("testlevel1");
    }
}
