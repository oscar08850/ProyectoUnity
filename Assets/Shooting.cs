using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject arrowPrefab;

    public float bulletForce = 50f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { 
           Shoot();
        }
     
    }


    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = arrow.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
