using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave1 : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {

        control player = collision.GetComponent<control>();


        if (player != null)
        {
            //Destruir llave
            Destroy(gameObject);

            // ACTIVAR BOOL
            if (!GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(1))
                GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetTrue(1);

       
        }
    }
}
