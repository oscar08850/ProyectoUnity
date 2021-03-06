using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoton : MonoBehaviour
{

    public Transform firePoint;
    public GameObject arrowPrefab;
    public control a;

    public float bulletForce = 50f;



    // Update is called once per frame
    void Update()
    {


    }




    void Shoot() //Disparo derecha
    {

        a.animator.SetTrigger("ShootPlayer"); //MOVEMENT STATE

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb2 = arrow.GetComponent<Rigidbody2D>();
        ConstantForce2D force2D = arrow.GetComponent<ConstantForce2D>();
        SpriteRenderer sprite = arrow.GetComponent<SpriteRenderer>();

        force2D.force = new Vector2(50, 0);
        sprite.flipX = false;

        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


    }

    void Shoot2()//Disparo Izquierda
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = arrow.GetComponent<Rigidbody2D>();
        ConstantForce2D force2D = arrow.GetComponent<ConstantForce2D>();
        SpriteRenderer sprite = arrow.GetComponent<SpriteRenderer>();
        force2D.force = new Vector2(-50, 0);
        sprite.flipX = true;
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
