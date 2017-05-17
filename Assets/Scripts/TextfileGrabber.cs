﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class TextfileGrabber : MonoBehaviour
{
    public TextAsset filename;
    public Text text;
    public int x;
    int Counter = 0;
    private float timer = 1;
    private int n = 100;
    public GameObject image;
    public GameObject Conversation1;
    private bool z = true;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        string[] dataLines = filename.text.Split(',');
        int Length = dataLines[x].Length;
        if (Counter != Length + 1)
        {
            text.text = "";
            text.text = dataLines[x].Substring(0, Counter);
            Counter += 1;
        }
    }

    public void function1(int var)
    {
        if(n > var)
        {
            n = var;
        }
        if(n > 0)
        {
            x += 1;
            Counter = 0;
            n -= 1;
        }
        else
        {
            Conversation1.SetActive(false);
        }
    }
}

