using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController3 : MonoBehaviour
{
    public float velocidad = 10f;

    Rigidbody2D rb;
    Animator animator;
    public ConstantForce2D force;

    Vector2 move;


    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = GetComponent<ConstantForce2D>();

        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        move = new Vector2();
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (move.x < 0)
        {
            transform.localScale = new Vector2(-0.5f, transform.localScale.y);
            force.force.Set(-10, 0);

        }

        else if (move.x > 0){
            transform.localScale = new Vector2(0.5f, 0.5f);
            force.force.Set(10, 0);
        }

        if (move != Vector2.zero) {
            animator.SetFloat("Movimiento X", move.x);
            animator.SetFloat("Movimiento Y", move.y);
            animator.SetBool("RunPlayer", true);
        }        

        else{
            animator.SetBool("RunPlayer", false);
        }


        rb.MovePosition(transform.position + (Vector3)move * Time.deltaTime * velocidad);
   

    }




}