using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    public Animator animator;

    public Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    public bool mirandoDerecha = false;

    //Variables de vida
    public int maxHealth = 100;
    public int currentHealth;
    /////////////////

    public Healthbar healthbar;
    

    public Rigidbody2D rb;
    public ConstantForce2D force;
    public float moveSpeed = 10.0f; //Cambiar valor para cambiar velocidad personaje


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = GetComponent<ConstantForce2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }



    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        movements();

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //GestionarOrientacion(Input.GetAxis("Horizontal"));



        Debug.Log("RunPlayer es: " + animator.GetBool("RunPlayer"));
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //Mirar si el 90 es correcto
        rb.rotation = angle;


    }


    void movements()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            if (movement.x < 0) //Pulso IZQUIERDA
            {
                if (mirandoDerecha == true) //VENGO DE MIRAR DERECHA
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                    mirandoDerecha = false;
                }
                else //VENGO DE MIRAR IZQUIERDA
                {
                    mirandoDerecha = false;
                }

            }
            else if (movement.x > 0) //Pulso DERECHA
            {
                if (mirandoDerecha == true) //VENGO DE MIRAR DERECHA
                {
                    mirandoDerecha = true;
                }
                else //VENGO DE MIRAR IZQUIERDA
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                    mirandoDerecha = true;
                }
            }

            animator.SetBool("RunPlayer", true); //MOVEMENT STATE
        }
        else
            animator.SetBool("RunPlayer", false); //IDLE STATE



        // transform.position = transform.position + movement * Time.deltaTime * velocidad;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

}