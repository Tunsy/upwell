using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour {

    private Text count;

	// Use this for initialization
	void Start () {
        count = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
        count.text = GameManager.instance.GetDeathCount().ToString();
	}
}
