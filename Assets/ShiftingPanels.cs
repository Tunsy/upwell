using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftingPanels : MonoBehaviour {

    public GameObject Panelset;
    private bool x = false;
    public Text text;

    public void shiftpanels()
    {
        if(x == false)
        {
            Panelset.GetComponent<RectTransform>().position = new Vector2(Panelset.GetComponent<RectTransform>().position.x - 784, Panelset.GetComponent<RectTransform>().position.y);
            x = true;
            text.text = "<                    <                   <";
        }
        else
        {
            Panelset.GetComponent<RectTransform>().position = new Vector2(Panelset.GetComponent<RectTransform>().position.x + 784, Panelset.GetComponent<RectTransform>().position.y);
            x = false;
            text.text = ">                    >                   >";
        }
    }
}
