using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    private float localX;
    public int distance = 1000;
    public int amount = 3;
    public AudioClip breakSound;
    public GameObject item;
    private GameObject[] spawned;
    // Use this for initialization
    void Start()
    {
        localX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" && (jumpedOn(collision)))
        {
            if (breakSound)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullit")
            Destroy(gameObject);
    }

    bool jumpedOn(Collision2D c)
    {
        return c.transform.position.y > transform.position.y && c.transform.position.x < localX + transform.position.x && c.transform.position.x > transform.position.x - localX;

    }

    private void OnDestroy()
    {
        spawned = new GameObject[amount];
        for (int i = 0; i < amount; ++i)
        {


            GameObject c = GameObject.Instantiate(item, transform.position, Quaternion.identity);
            float ang = Random.Range(0, Mathf.PI);

            c.GetComponent<Rigidbody2D>().AddForce(distance * new Vector2(Mathf.Cos(ang), Mathf.Sin(ang)));
            //
            spawned[i] = c;
        }

         foreach(GameObject c in spawned)
         {
            Physics2D.IgnoreCollision(c.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
             
         }
        Invoke("invoker", 1/5);
      
    }

    void invoker()
    {
        foreach (GameObject c in spawned)
        {


            Physics2D.IgnoreCollision(c.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>(), false);
        }
    }

}
