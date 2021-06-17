using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinajaRompeScript : MonoBehaviour
{
    public int health = 50;

    public GameObject llave;

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage: " + damage + "health: " + health);
        health -= damage; //Resta Damage a Health

        if (health <= 0)
        {
            StartCoroutine(Die());

        }
    }

    IEnumerator Die()
    {
        Destroy(gameObject, 2f);
        yield return new WaitForSecondsRealtime(0f);
        DropLlave();

    }

    void DropLlave()
    {
        Vector2 position = transform.position;
        Instantiate(llave, position, Quaternion.identity);
    }
}
