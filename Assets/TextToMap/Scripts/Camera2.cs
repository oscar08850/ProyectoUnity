using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.


    Vector3 vel = Vector3.zero;

    public float suavidadCamara = .15f;

    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // this is goint to find a certain tagged object from hirarchey and assing it to target.

        Vector3 playerpos2 = target.position;


        Vector3 playerpos = target.position;
        playerpos2.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, playerpos2, ref vel, suavidadCamara);
    }
}
