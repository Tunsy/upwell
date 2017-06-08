using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
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
        if (GameManager.instance.GetDeathCount() <= 0 && !alreadyActivated && collision.tag == "Player")
        {
            conversation.SetActive(true);
            textGrabber.ChangeStart(startingX, linesNum);
            Time.timeScale = 0;
            alreadyActivated = true;
        }

    }

    public void OnMouseDown()
    {
        if (GameManager.instance.GetDeathCount() <= 0 && !alreadyActivated)
        {
            conversation.SetActive(true);
            textGrabber.ChangeStart(startingX, linesNum);
            Time.timeScale = 0;
            alreadyActivated = true;
        }
    }
}
