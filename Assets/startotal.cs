using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startotal : MonoBehaviour {

    public Text text;
    private int total;
    public GameObject manager;
    private string[] array;
    private bool initial;

    void Start()
    {
        text = this.GetComponent<Text>();
        array = new string[] { "Level 1-1", "Level 1-2", "Level 1-3", "Level 2-1", "Level 2-2", "Level 2-3", "Level 3-1", "Level 3-2", "Level 3-3" };
        initial = false;
    }

    void Update()
    {

            if (initial == false)
            {
                for (int i = 0; i < 9; i++)
                {
                    total += manager.GetComponent<ScoreManager>().starsForLevel(array[i]);
                }
                initial = true;
            }
            text.text = "Total: " + total;
	}
}
