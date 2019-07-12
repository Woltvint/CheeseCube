using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float speed;

    private bool dir;
    private Rigidbody2D rb;
    private Vector3 start;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        start = transform.position;
    }

    void FixedUpdate()
    {
        if (dir)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        transform.position = new Vector3(transform.position.x, start.y, transform.position.z);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            dir = !dir;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
