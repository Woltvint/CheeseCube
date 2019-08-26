using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public float chargeTime;
    public GameObject teleportEffect;
    public string levelName;

    private bool isActivated = false;
    private bool isTeleporting = false;
    private float activeTime = 0;
    private ParticleSystem ps;

    private void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
    }

    void FixedUpdate()
    {
        if (activeTime > chargeTime && !isTeleporting)
        {
            isTeleporting = true;
            StartCoroutine(ChangeLevel());
        }

        if (isActivated)
        {
            if (Input.GetButton("Submit"))
            {
                activeTime += chargeTime;
            }
            activeTime += Time.deltaTime;
        }
    }

    public IEnumerator ChangeLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>().hide();
        Instantiate(teleportEffect,GameObject.FindGameObjectWithTag("Player").transform.position,Quaternion.identity);
        GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>());
        SceneManager.LoadScene(levelName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isActivated = true;
            ps.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isActivated = false;
            activeTime = 0;
            ps.Stop();
        }
    }
}
