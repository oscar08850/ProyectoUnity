using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinajaVaciaScript : MonoBehaviour
{
    public int health = 50;
    


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
    }

}
