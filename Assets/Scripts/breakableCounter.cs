using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableCounter : MonoBehaviour {
    public int durability;
    public GameObject[] activatedPlatforms;
    public AudioClip breakSound;
    public bool spawnsObject;

    private void Start()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
            if (durability <= 0)
            {
                ActivateEvent();
            }
            if(breakSound)
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

            Destroy(gameObject);
        }
    }

    private void ActivateEvent()
    {
        if (spawnsObject)
        {
            for (int i = 0; i < activatedPlatforms.Length; i++)
            {
                activatedPlatforms[i].SetActive(true); ;
            }
        }
        else
        {
            for (int i = 0; i < activatedPlatforms.Length; i++)
            {
                Destroy(activatedPlatforms[i]);
            }
        }

    }
   

    
}
