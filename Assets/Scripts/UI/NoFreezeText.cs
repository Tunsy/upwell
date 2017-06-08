using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoFreezeText : MonoBehaviour
{

    public GameObject conversation;
    public GameObject grabber;
    private TextfileGrabber textGrabber;
    public int startingX;
    public int linesNum;

    public void Start()
    {
        textGrabber = grabber.GetComponent<TextfileGrabber>();
    }

    void OnTriggerEnter2D()
    {
        conversation.SetActive(true);
        textGrabber.ChangeStart(startingX, linesNum);
    }

    void OnMouseDown()
    {
        conversation.SetActive(true);
        textGrabber.ChangeStart(startingX, linesNum);
    }
}
