using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{

    public int health = 100;
    Animator animator;

    public GameObject lapida;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("knightDie", false); //MOVEMENT STATE

    }
    public void TakeDamage (int damage)
    {
        Debug.Log("Damage: " + damage + "health: " + health);
        health -= damage; //Resta Damage a Health

        if (health <= 0)
        {
            animator.SetBool("knightDie", true); //MOVEMENT STATE
            
            StartCoroutine( Die());

        }
    }

    IEnumerator Die()
    {
        Destroy(gameObject,2f);
        yield return new WaitForSeconds(1.99f);
        DropLapida();

    }

    void DropLapida()
    {
        Vector2 position = transform.position;
        Instantiate(lapida, position, Quaternion.identity);
    }
}
