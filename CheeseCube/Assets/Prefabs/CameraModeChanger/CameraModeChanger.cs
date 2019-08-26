using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeChanger : MonoBehaviour
{
    private Camera_Movement cam;

    public Vector3 camOrigin;
    public bool move_x;
    public bool move_y;
    public bool move_xy;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Movement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            cam.origin = camOrigin;
            cam.move_x = move_x;
            cam.move_y = move_y;
            cam.move_xy = move_xy;
        }
    } 

}
