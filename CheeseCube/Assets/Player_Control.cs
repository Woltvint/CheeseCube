using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float jumpDist;

    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {

        if (Input.GetButton("Left"))
        {
            rb.velocity = new Vector3(-speed,rb.velocity.y,0);
        }

        if (Input.GetButton("Right"))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }

        RaycastHit ray;
        Physics.Raycast(transform.position, Vector3.down,out ray, 10.0f);
        if (Input.GetButton("Jump") && ray.distance <= jumpDist)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
