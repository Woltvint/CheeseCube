using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject DeathParticles;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameObject go = Instantiate(DeathParticles, transform.position, transform.rotation, transform.parent);
            go.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponentInParent<Game_Manager>().StartCoroutine(gameObject.GetComponentInParent<Game_Manager>().ResetLevel());
            Destroy(gameObject);
        }
    }

}
