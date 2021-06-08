using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float velocidad = 10f;
    
    Rigidbody2D rb;
    Animator animator;
    public GameObject crosshair;
    public float CROSSHAIR_DISTANCE = 1.0f;
    public bool derecha = true;

    Vector2 move;

    
    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            derecha = true;
        }
        else if (move.x > 0)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            derecha = false;
        }


        if (move != Vector2.zero)
        {
            animator.SetFloat("Movimiento X", move.x);
            animator.SetFloat("Movimiento Y", move.y);
            animator.SetBool("RunPlayer", true);
        }
        else
        {
            animator.SetBool("RunPlayer", false);
        }
        

        rb.MovePosition(transform.position + (Vector3)move * Time.deltaTime * velocidad);
        Aim();
            
    }

    void Aim()
    {
        if (move != Vector2.zero)
        {
            crosshair.transform.localPosition = move * CROSSHAIR_DISTANCE;
        }
    }

   
}
