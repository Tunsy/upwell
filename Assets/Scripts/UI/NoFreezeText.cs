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
    public bool alreadyActivated;

    public void Start()
    {
        textGrabber = grabber.GetComponent<TextfileGrabber>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyActivated && collision.tag == "Player")
        {
            conversation.SetActive(true);
            textGrabber.ChangeStart(startingX, linesNum);
            alreadyActivated = true;
        }
    }

    void OnMouseDown()
    {
        if (!alreadyActivated)
        {
            conversation.SetActive(true);
            textGrabber.ChangeStart(startingX, linesNum);
            alreadyActivated = true;
        }
    }
}
