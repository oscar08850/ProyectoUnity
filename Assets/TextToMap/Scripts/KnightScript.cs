using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{

    public int health = 100;
    Animator animator;

    public GameObject deathEffect;

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
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject,2f);

    }
}
