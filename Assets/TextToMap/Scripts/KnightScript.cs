using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{

    public float visionRadius;
    public float speed;
    Vector3 initialPosition;
    
    public int health = 100;
    Animator animator;

    public GameObject lapida;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.SetBool("knightDie", false); //MOVEMENT STATE

    }

    void Update()
    {
        
        Vector3 target = initialPosition;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
            target = player.transform.position;
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
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
