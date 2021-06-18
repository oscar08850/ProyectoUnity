using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinajaLlaveScript : MonoBehaviour
{
    public int health = 20;

    public GameObject llave;

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage: " + damage + "health: " + health);
        health -= damage; //Resta Damage a Health

        if (health <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Destroy(gameObject);
        DropLlave();
    }

    void DropLlave()
    {
        Vector2 position = transform.position;
        Instantiate(llave, position, Quaternion.identity);
    }
}
