using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
<<<<<<< HEAD
=======
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

>>>>>>> bd5eeb8ad2befd034b1b30dcd28f9874e23eca6f
    public float visionRadius;
    public float ataqueRadius;
    public float speed;
    Vector3 initialPosition;
    Vector3 currentPosition;

    public int health = 100;
    Animator animator;

    public GameObject lapida;
    public GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.SetBool("knightDie", false); //TOY VIVO

    }

    void Update()
    {
<<<<<<< HEAD
=======

>>>>>>> bd5eeb8ad2befd034b1b30dcd28f9874e23eca6f
        Vector3 target = initialPosition;
        currentPosition = transform.position;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
<<<<<<< HEAD
            target = player.transform.position;
            //animator.SetBool("knightRun", true);
            //animator.SetBool("knightAttack", false);
        }
            /*
        else if (dist < ataqueRadius)
        {
            target = player.transform.position;
            //animator.SetBool("knightAttack", true);
            //animator.SetBool("knightRun", false);
        }*/
=======
            mirarAlPlayer();

            animator.SetBool("knightRun", true); //VOY HACIA EL PLAYER

            target = player.transform.position;
            if (dist < attackRange)
            {
                Attack();
            }
        }
        else if (dist > visionRadius)
        {
            if (currentPosition == initialPosition)
            {
                animator.SetBool("knightRun", false); //Estoy donde empiezo asi que IDLE
            }
        }
        if (animator.GetBool("knightDie") == true)
        {
            target = this.transform.position; //La lapida se queda donde muere.
        }
>>>>>>> bd5eeb8ad2befd034b1b30dcd28f9874e23eca6f
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        

        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage: " + damage + "health: " + health);
        health -= damage; //Resta Damage a Health

        if (health <= 0)
        {
            animator.SetBool("knightDie", true); //MOVEMENT STATE

            StartCoroutine(Die());

        }
    }

    void Attack()
    {
        animator.SetTrigger("knightAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit:  " + enemy.name);

        }

    }


    IEnumerator Die()
    {
        Destroy(gameObject, 2f);
        yield return new WaitForSeconds(1.99f);
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
}
