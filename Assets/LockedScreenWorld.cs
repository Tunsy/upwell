using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedScreenWorld : MonoBehaviour {

    public int total;
    public GameObject manager;
    public Text text;
    private string[] array;
    private bool initial;
    public Image mypanel1;
    public Image mypanel2;
    public Image mypanel3;
    static bool two;

    void Start ()
    {
        array = new string[] { "Level 1-1", "Level 1-2", "Level 1-3", "Level 2-1", "Level 2-2", "Level 2-3", "Level 3-1", "Level 3-2", "Level 3-3" };
        initial = false;
        manager = GameObject.Find("ScoreManager");
    }
	
	void Update ()
    {
        /*if (two == true)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            total += 1;*/
            if (initial == false)
            {
                for (int i = 0; i < 9; i++)
                {
                    total += manager.GetComponent<ScoreManager>().starsForLevel(array[i]);
                }
                initial = true;
            }

            if (total >= 30)
            {
                this.gameObject.SetActive(false);
                /*mypanel1.CrossFadeAlpha(0.1f, 1.0f, false);
                mypanel2.CrossFadeAlpha(0.1f, 1.0f, false);
                mypanel3.CrossFadeAlpha(0.1f, 1.0f, false);
                text.text = "";
            }*/
        }
    }
}
