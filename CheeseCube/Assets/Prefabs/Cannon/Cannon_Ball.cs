using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball : MonoBehaviour
{
    public GameObject destroyParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Ground")
        {
            Instantiate(destroyParticles,transform.position,Quaternion.identity,transform.parent);
            Destroy(gameObject);
        }
    }

}
