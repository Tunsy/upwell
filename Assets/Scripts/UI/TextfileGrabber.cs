using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class TextfileGrabber : MonoBehaviour
{
    public TextAsset filename;
    public Text text;
    public int startingLine;
    private int y;
    public int length;
    int Counter = 0;
    private float timer = 1;
    private int n = 100;
    public GameObject image;
    public GameObject conversation;
    private bool z = true;
    public bool alreadyActivated;

    void Start()
    {
        text = this.GetComponent<Text>();
        y = startingLine;
    }

    public void ChangeStart(int starting, int length)
    {
        startingLine = starting;
        y = starting;
        this.length = length;
    }

    void Update()
    {
        string[] dataLines = filename.text.Split(',');
        int Length = dataLines[startingLine].Length;
        if (Counter != Length + 1)
        {
            text.text = "";
            text.text = dataLines[startingLine].Substring(0, Counter);
            Counter += 1;
        }

        if (Input.anyKeyDown)
        {
            if (n > length)
            {
                n = length;
            }
            if (n > 0)
            {
                startingLine += 1;
                Counter = 0;
                n -= 1;
            }
            else
            {
                Time.timeScale = 1;
                conversation.SetActive(false);
                startingLine = y;
                n = 100;
                Counter = 0;
                alreadyActivated = true;
            }
        }
    }
}

