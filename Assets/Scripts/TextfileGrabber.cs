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
    private int lineNum = 0;
    public int x;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        string[] dataLines = filename.text.Split(',');
        Debug.Log(dataLines[x]);
        text.text = "" + dataLines[x];
    }
}

