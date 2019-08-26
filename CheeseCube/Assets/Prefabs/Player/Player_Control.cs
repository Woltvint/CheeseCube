using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float jumpDist, jumpSpeed, moveSpeed;
    public float timeToJump;
    public bool friction;
    public bool controlable = true;

    public bool maxFallSpeedCheck;
    public float maxFallSpeed;

    public float T = 0;
    public Rigidbody2D rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!controlable)
        {
            return;
        }


        RaycastHit2D rayLeft = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), new Vector2(0, -1), jumpDist);
        RaycastHit2D rayMid = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), new Vector2(0, -1), jumpDist);
        RaycastHit2D rayRight = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0), new Vector2(0, -1), jumpDist);

        RaycastHit2D hit = rayMid;

        bool can = false;

        if (rayLeft && rayLeft.distance < jumpDist && rayLeft.collider.tag == "Ground") { can = true; hit = rayLeft; }
        if (rayMid && rayMid.distance < jumpDist && rayMid.collider.tag == "Ground") { can = true; hit = rayMid; }
        if (rayRight && rayRight.distance < jumpDist && rayRight.collider.tag == "Ground") { can = true; hit = rayRight; }

        if (!friction)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        //moving

        if (Input.GetButton("Left"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetButton("Right"))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (can && hit.transform.gameObject.GetComponent<Rigidbody2D>())
        {
            rb.velocity += new Vector2(hit.transform.gameObject.GetComponent<Rigidbody2D>().velocity.x, rb.velocity.y);
        }
        

        //speedcheck

        if (rb.velocity.y < -maxFallSpeed && maxFallSpeedCheck)
        {
            rb.velocity = new Vector2(rb.velocity.x,-maxFallSpeed);
        }


        //jumping

        if (can)
        {
            T += Time.deltaTime;
        }

        if (Input.GetButton("Jump") && T > timeToJump && can)
        {   
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            T = 0;
        }
    }

    public void hide()
    {
        controlable = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
