using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExploder : MonoBehaviour
{
    public float speed;
    public GameObject exploder;
    private Rigidbody2D rb;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x * speed, rb.velocity.y + speed);
    }

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction;
        rb.velocity = new Vector2(rb.velocity.x * speed, rb.velocity.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        GameObject expl = GameObject.Instantiate(exploder);
        expl.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        Destroy(gameObject);
        

    }

    private void OnDestroy()
    {

        
        Debug.Log("new expl");
    }






}
