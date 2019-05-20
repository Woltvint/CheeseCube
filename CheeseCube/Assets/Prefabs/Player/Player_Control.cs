using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float jumpDist, jumpSpeed, moveSpeed;

    private Rigidbody2D rb;
    public bool friction = false;

    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Left"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetButton("Right"))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (!friction)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetButton("Jump"))
        {
            RaycastHit2D rayLeft = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), new Vector2(0, -1), jumpDist);
            RaycastHit2D rayMid = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), new Vector2(0, -1), jumpDist);
            RaycastHit2D rayRight = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0), new Vector2(0, -1), jumpDist);

            bool can = false;

            if (rayLeft && rayLeft.distance < jumpDist && rayLeft.collider.tag == "Ground") {can = true;}
            if (rayMid && rayMid.distance < jumpDist && rayMid.collider.tag == "Ground") { can = true; }
            if (rayRight && rayRight.distance < jumpDist && rayRight.collider.tag == "Ground") { can = true; }

            if (can)
            {
                rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
            }
        }

    }
}
