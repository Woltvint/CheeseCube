using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public bool move_x = false;
    public bool move_y = false;
    public bool move_xy = false;
    public float speed = 0;

    public Vector3 origin;
    private Vector3 destpos;


    private void Start()
    {
        origin = cam.position;
    }

    private void FixedUpdate()
    {
        if (!player)
        {
            return;
        }

        if (move_x)
        {
            destpos = new Vector3(player.position[0], origin[1], origin[2]);
            cam.position = Vector3.Lerp(cam.position, destpos, speed);
        }

        if (move_y)
        {
            destpos = new Vector3(origin[0], player.position[1], origin[2]);
            cam.position = Vector3.Lerp(cam.position, destpos, speed);
        }

        if (move_xy)
        {
            destpos = player.position + new Vector3(0, 0, origin[2]);
            cam.position = Vector3.Lerp(cam.position, destpos, speed);
        }
    }
}
