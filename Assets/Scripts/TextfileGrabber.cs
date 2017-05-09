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
    public int x;
    int Counter = 0;
    private float timer = 1;
    public GameObject image;
    private bool y = true;
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
            else
        {
            y = false;
        }

        if (y == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                image.SetActive(z);
                z = !z;
                timer += 1;
            }   
        }  
    }
}

