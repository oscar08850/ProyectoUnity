using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinajaMonedaScript : MonoBehaviour
{
    public int health = 20;

    public GameObject moneda;

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
        DropMoneda();
    }

    void DropMoneda()
    {
        Vector2 position = transform.position;
        Instantiate(moneda, position, Quaternion.identity);
    }
}
