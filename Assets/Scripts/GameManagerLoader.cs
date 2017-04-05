    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
public class GameManagerLoader : MonoBehaviour
{

    public GameObject gameManager;          //GameManager prefab to instantiate.



    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameManager);

    }
}
