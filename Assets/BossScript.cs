using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 2.7f;
    public LayerMask enemyLayers;
    public control contr;
    bool muerto = false;


    public float visionRadius;
    public float speed;
    Vector3 initialPosition;
    Vector3 currentPosition;

    public int health = 600;

    public GameObject lapida;
    public GameObject llave;
    public GameObject player;

    public float attackRate = 0.8f;
    float nextAttackTime = 0f;





    private void Start()
    {
        contr = GameObject.FindGameObjectWithTag("Player").GetComponent<control>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
     //   animator = GetComponent<Animator>();
    }

    void Update()
    {
        comportamiento();

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage: " + damage + "health: " + health);
        health -= damage; //Resta Damage a Health

        if (health <= 0 && muerto == false)
        {
           // animator.SetTrigger("knightDie");
            muerto = true;

            // animator.SetBool("knightDie", true); //MOVEMENT STATE

            StartCoroutine(Die());

        }
    }

    void Attack()
    {
       // animator.SetTrigger("knightAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        bool hit = false;

        foreach (Collider2D player in hitEnemies)
        {
            if (hitEnemies != null)
                hit = true;
        }
        if (hit)
        {
            contr.TakeDamage(20);
        }

    }

    IEnumerator Die()
    {
        Destroy(gameObject, 2f);
        GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().AddMuertos(1);

        yield return new WaitForSecondsRealtime(1.8f);

        DropLapida();



        DropLlave();

    }

    void DropLapida()
    {
        Vector2 position = transform.position;
        Instantiate(lapida, position, Quaternion.identity);
    }

    void DropLlave()
    {
        Vector2 position = transform.position;
        Instantiate(llave, position, Quaternion.identity);
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
    public void noMirarAlPlayer()
    {
        if (player.transform.position.x - transform.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
            transform.eulerAngles = new Vector3(0, 180, 0);
    }


    public void comportamiento()
    {
        Vector3 target = initialPosition;
        currentPosition = transform.position;
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < visionRadius)
        {
            target = player.transform.position;
            //animator.SetBool("knightRun", true);
            if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetHealth() <= 0)
            {
                noMirarAlPlayer();
                target = initialPosition;
                if (currentPosition == initialPosition)
                {
                  //  animator.SetBool("knightRun", false);
                }
            }
            else mirarAlPlayer();
        }
        else
        { //dist > visionRadius  // Player fuera de rango de vision
            target = initialPosition;
            if (currentPosition == initialPosition)
            {
               // animator.SetBool("knightRun", false);
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
