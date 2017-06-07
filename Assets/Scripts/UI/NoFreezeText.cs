using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoFreezeText : MonoBehaviour
{

    public GameObject conversation;
    public GameObject grabber;
    public int startingX;
    public int linesNum;

    public void Start()
    {
        //grabber = FindObjectOfType<TextfileGrabber>();
    }

    void OnTriggerEnter2D()
    {
        conversation.SetActive(true);
        grabber.GetComponent<TextfileGrabber>().ChangeStart(startingX, linesNum);
        Time.timeScale = 0;
    }

    void OnMouseDown()
    {
        conversation.SetActive(true);
        grabber.GetComponent<TextfileGrabber>().ChangeStart(startingX, linesNum);
        Time.timeScale = 0;
    }
}
