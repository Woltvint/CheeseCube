using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public string triggerTag;
    public int triggerCount;

    void Update()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag(triggerTag);
        if (go.Length <= triggerCount)
        {
            ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
            ps.Stop();
            
            BoxCollider2D[] bc = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in bc)
            {
                box.enabled = false;
            }
        }
    }
}
