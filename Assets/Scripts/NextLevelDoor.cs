using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour {

    public GameObject LevelSummaryUI;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Time.timeScale = 0;
            GameManager.instance.setHighScore();
            LevelSummaryUI.SetActive(true);
           
        }
    }
}
