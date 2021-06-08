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
        Debug.Log(a.mirandoDerecha);
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
        force2D.force = new Vector2(50, 0);
        //derecha = FindObjectOfType<control>();

        //getcomponent<ConstantForce2D>().force = new Vector2(50,50);



        //rb2.GetComponent<ConstantForce2D>.bulletForce = new Vector2(60, 60);

        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


    }

    void Shoot2()//Disparo Izquierda
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = arrow.GetComponent<Rigidbody2D>();
        ConstantForce2D force2D = arrow.GetComponent<ConstantForce2D>();
        force2D.force = new Vector2(-50, 0);

        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);



    }
}
