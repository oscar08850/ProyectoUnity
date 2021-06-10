using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject arrowPrefab;
    public control a;

    public float bulletForce = 50f;
    

    
    // Update is called once per frame
    void Update()
    {
        if (a.mirandoDerecha == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Estamos dentro");
                Shoot2();
            }
        }
        

  
     
    }


    void Shoot() //Disparo derecha
    {
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
