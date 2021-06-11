using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    GameObject objeto;
    int damage = 40;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide (name) : " + collision.collider.gameObject.name);
        Debug.Log("collide (tag) : " + collision.collider.gameObject.tag);
        Destroy(gameObject, 2f);

    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        KnightScript knight = hitInfo.GetComponent<KnightScript>();
        Debug.Log(hitInfo.name);
        if (knight != null)
        {
            knight.TakeDamage(damage);
        }
        Destroy(gameObject, 0f);
    }
}
