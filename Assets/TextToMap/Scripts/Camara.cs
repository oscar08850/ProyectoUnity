using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;

    Vector3 vel = Vector3.zero;

    public float suavidadCamara = .15f;

    void FixedUpdate()
    {
        Vector3 playerpos = player.position;
        playerpos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, playerpos, ref vel, suavidadCamara);
    }
}
