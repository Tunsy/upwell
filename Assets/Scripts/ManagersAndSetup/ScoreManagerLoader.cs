using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerLoader : MonoBehaviour {

    public GameObject scoreManager;          //GameManager prefab to instantiate.



    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (ScoreManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(scoreManager);

    }
}
