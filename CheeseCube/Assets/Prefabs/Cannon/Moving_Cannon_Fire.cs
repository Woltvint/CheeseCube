using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Cannon_Fire : MonoBehaviour
{

    public GameObject cannonBall;
    public GameObject fireParticles;
    public float fireSpeed;
    public float timeOffset;

    public Transform cannonBarrel;
    public Transform firePoint;

    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        StartCoroutine(startCannon());
    }


    IEnumerator startCannon()
    {
        yield return new WaitForSeconds(timeOffset);
        gameObject.GetComponent<Animator>().enabled = true;
    }

    public void Fire()
    {
        GameObject ball = Instantiate(cannonBall, cannonBarrel.position, cannonBarrel.rotation, cannonBarrel);
        ball.GetComponent<Rigidbody2D>().velocity = (firePoint.position - cannonBarrel.position) * fireSpeed;
        Instantiate(fireParticles,firePoint.position,firePoint.rotation,firePoint);
    }
}
