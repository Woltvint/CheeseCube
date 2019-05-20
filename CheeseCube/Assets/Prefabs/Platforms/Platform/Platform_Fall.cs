using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Fall : MonoBehaviour
{
    bool falling = false;

    public GameObject prefallParticles;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(2);
        rb.bodyType = RigidbodyType2D.Dynamic;

        BoxCollider2D[] bc = gameObject.GetComponents<BoxCollider2D>();

        foreach (BoxCollider2D box in bc)
        {
            box.enabled = false;
        }

        yield return new WaitForSeconds(10);

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!falling)
        {
            Instantiate(prefallParticles,transform.position,transform.rotation,transform);
            StartCoroutine(fall());
            falling = true;
        }
    }
}
