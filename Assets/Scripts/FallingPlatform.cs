using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    public float fallTime; //never enter in as negative
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator platformShake(float fallTime)
    {
        while (fallTime > 0)
        {
            rb.position = new Vector2(rb.position.x + (Random.insideUnitCircle.x * 0.05f), rb.position.y + (Random.insideUnitCircle.x * 0.075f));
            yield return new WaitForSeconds(0.0001f);
            fallTime -= Time.deltaTime;
        }

        rb.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Player")
        {
            StartCoroutine(platformShake(fallTime));
        }
    }
}
