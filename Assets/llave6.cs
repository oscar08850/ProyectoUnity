﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave6 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        control player = collision.GetComponent<control>();


        if (player != null)
        {
            // ACTIVAR BOOL
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetTrue(6);

            //Destruir llave
            Destroy(gameObject);
        }
    }
}