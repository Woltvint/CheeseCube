using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireInterval;
    public GameObject ball;
    public Vector3 ballOffset;

    private float time; 

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if (time > fireInterval)
        {
            GameObject gl = Instantiate(ball,transform.position-ballOffset,Quaternion.identity,transform);
            GameObject gr = Instantiate(ball, transform.position+ballOffset, Quaternion.identity, transform);
            gl.GetComponent<Cannon_Ball>().speed = -gl.GetComponent<Cannon_Ball>().speed;
            time = 0;
        }
    }

}
