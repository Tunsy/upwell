using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {

    public GameObject Conversation1;
    public bool x = true;

    void OnTriggerEnter2D()
    {
        Conversation1.SetActive(x);
        Time.timeScale = 0;
    }
    
    void OnMouseDown()
    {
        Conversation1.SetActive(x);
        Time.timeScale = 0;
    }
}
