using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Sprite on;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.tag = "Untagged";
            gameObject.GetComponent<SpriteRenderer>().sprite = on;
        }
    }
}
