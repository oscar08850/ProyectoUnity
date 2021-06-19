using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyJoystick;

public class control : MonoBehaviour
{

    public Animator animator;

    [SerializeField] public float speed;
    [SerializeField] public Joystick joystick;
    private float movX, movY;


    public Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    public bool mirandoDerecha = false;

    public bool muerto = false;

    //Variables de vida
    public int maxHealth = 100;
    public int currentHealth;
    /////////////////

    public Healthbar healthbar;
    ScoreManager score;

    private Button button;

    public Rigidbody2D rb;
    public ConstantForce2D force;
    public float moveSpeed = 10.0f; //Cambiar valor para cambiar velocidad personaje

    private void Awake()
    {
        this.joystick = FindObjectOfType<Joystick>();
    }

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
        currentHealth = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetHealth();
        if (currentHealth <= 0 && muerto == false)
        {
            muerto = true;
            animator.SetTrigger("PlayerDie");
        }
        else if (muerto == false)
        {
            movements();
        }
        healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>();
        healthbar.SetHealth(GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetHealth());

        GameObject.FindGameObjectWithTag("Coin").GetComponent<ScoreManager>().PintarScore();

        //button = GameObject.FindGameObjectWithTag("PocimaRoja").GetComponent<Button>();
        //button.onClick

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




#if UNITY_STANDALONE || UNITY_WEBPLAYER

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

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE


        movX = joystick.Horizontal();
        movY = joystick.Vertical();
        movement = new Vector2(movX,movY);

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

       // transform.position += new Vector3(movX, movY, 0f) * speed * Time.deltaTime;

#endif
        // transform.position = transform.position + movement * Time.deltaTime * velocidad;

    }

    public void TakeDamage(int damage)
    {

        currentHealth = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetHealthDamage(damage);
        healthbar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().AddMonedas(1);
            GameObject.FindGameObjectWithTag("Coin").GetComponent<ScoreManager>().PintarScore();
        }
    }
}
