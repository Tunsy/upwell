using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoFreezeText : MonoBehaviour
{

    public GameObject conversation;
    private TextfileGrabber grabber;
    public int startingX;
    public int linesNum;

    public void Start()
    {
        grabber = FindObjectOfType<TextfileGrabber>();
    }

    void OnTriggerEnter2D()
    {
        conversation.SetActive(true);
        grabber.ChangeStart(startingX, linesNum);
        Time.timeScale = 0;
    }

    void OnMouseDown()
    {
        conversation.SetActive(true);
        //grabber.ChangeStart(startingX, linesNum);
        Time.timeScale = 0;
    }
}
