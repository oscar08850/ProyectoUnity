using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public control contr;

    public float visionRadius;
    public float ataqueRadius;
    public float speed;
    Vector3 initialPosition;
    Vector3 currentPosition;

    public int health = 100;
    Animator animator;

    public GameObject lapida;
    public GameObject player;

    public float attackRate = 0.02f;
    float nextAttackTime = 0f;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        //animator.SetBool("knightDie", false); //TOY VIVO

    }

    void Update()
    {
        comportamiento();
     
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage: " + damage + "health: " + health);
        health -= damage; //Resta Damage a Health

        if (health <= 0)
        {
            animator.SetTrigger("knightDie");

            // animator.SetBool("knightDie", true); //MOVEMENT STATE

            StartCoroutine(Die());

        }
    }

    void Attack()
    {
        animator.SetTrigger("knightAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        bool hit = false;

        foreach (Collider2D player in hitEnemies)
        {
            if (hitEnemies != null)
                hit = true;
        }
        if (hit)
            
            contr.TakeDamage(10);


    }

    IEnumerator Die()
    {
        Destroy(gameObject, 2f);
        yield return new WaitForSecondsRealtime (1.8f);
        DropLapida();

    }

    void DropLapida()
    {
        Vector2 position = transform.position;
        Instantiate(lapida, position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void mirarAlPlayer()
    {
        if (player.transform.position.x - transform.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
            transform.eulerAngles = new Vector3(0, 0, 0);

    }


    public void comportamiento() {
        Vector3 target = initialPosition;
        currentPosition = transform.position;
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < visionRadius)
        {
            target = player.transform.position;
            animator.SetBool("knightRun", true);
            mirarAlPlayer();
            //animator.SetBool("knightAttack", false);
        }
        else { //dist > visionRadius  // Player fuera de rango de vision
            target = initialPosition;
            if (currentPosition == initialPosition)
            {
                animator.SetBool("knightRun", false);
            }
        }


        if (dist < attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        
        if (health <= 0)
        {
            target = this.transform.position; //La lapida se queda donde muere.
        }
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

    }


}
