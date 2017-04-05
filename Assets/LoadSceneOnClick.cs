using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	
	public void LoadByIndex (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadLevel1()
    {
        GameManager.instance.InitializeValues();
        SceneManager.LoadScene("level1");
    }

    public void LoadMainLevel()
    {
        SceneManager.LoadScene("gametest");
        //GameManager.instance.StartGame();
    }
}
