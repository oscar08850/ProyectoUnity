using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    GameObject objeto;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject, 2f);
    }
}
