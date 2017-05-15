using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour {

    public GameObject LevelSummaryUI;
    public AudioClip levelCompleteSound;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(levelCompleteSound != null)
            {
                AudioSource.PlayClipAtPoint(levelCompleteSound, Camera.main.transform.position);
            }
            Time.timeScale = 0;
            GameManager.instance.setHighScores();
            GameManager.instance.setStars();
            Debug.Log(ScoreManager.instance.timeHighScore("Level 1-1"));
            LevelSummaryUI.SetActive(true);
           
        }
    }
}
