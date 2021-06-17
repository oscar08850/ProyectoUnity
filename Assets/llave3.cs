using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        control player = collision.GetComponent<control>();


        if (player != null)
        {
            // ACTIVAR BOOL
            if (!GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(3))
                GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetTrue(3);

            //Destruir llave
            Destroy(gameObject);
        }
    }
}
