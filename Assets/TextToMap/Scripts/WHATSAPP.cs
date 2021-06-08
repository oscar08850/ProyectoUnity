using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WHATSAPP : MonoBehaviour
{

    Animator animator;

    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    private bool mirandoDerecha = true;


    public Rigidbody2D rb;
    public ConstantForce2D force;
    public float moveSpeed = 25.0f; //Cambiar valor para cambiar velocidad personaje


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = GetComponent<ConstantForce2D>();
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        GestionarOrientacion(Input.GetAxis("Horizontal"));
        //movements();
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

            if (movement.x < 0)
                transform.localScale = new Vector2(0.5f, transform.localScale.y);
            else if (movement.x > 0)
                transform.localScale = new Vector2(0.5f, 0.5f);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            animator.SetBool("RunPlayer", true); //MOVEMENT STATE
        }
        else
            animator.SetBool("RunPlayer", false); //IDLE STATE


        // transform.position = transform.position + movement * Time.deltaTime * velocidad;
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || (mirandoDerecha == false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }
    }

}