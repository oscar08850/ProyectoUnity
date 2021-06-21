using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarInfoBotonesScript : MonoBehaviour
{
    public GameObject EstadoJuego;

    public int pocimaAzul = 0; //BaseDatos
    public int pocimaRoja = 0; //BaseDatos
    public int manzana = 0; //BaseDatos


    // Disparar

    public Transform firePoint;
    public GameObject arrowPrefab;
    public control a;

    public float bulletForce = 50f;
    //


    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<control>();
    }

    // Update is called once per frame
    void Update()
    {
        //Disparo
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<control>();


        ///

        pocimaRoja = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetPocionRoja();
        pocimaAzul = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetPocionAzul();
        manzana = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetManzana();
    }


    public void PocimaAzul()
    {
        if (this.pocimaAzul > 0)
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().PocimaAzul();
        }
    }

    public void PocimaRoja()
    {
        if (this.pocimaRoja > 0)
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().PocimaRoja();
        }
    }

    public void Manzana()
    {
        if (this.manzana > 0)
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().Manzana();
        }
    }


    public void disparo()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<control>().getMirandoDerecha() == true)
        {
            Shoot();
            this.a.animator.SetTrigger("ShootPlayer"); //MOVEMENT STATE
        }

        else
        {
            Shoot2();
            this.a.animator.SetTrigger("ShootPlayer"); //MOVEMENT STATE
        }
    }

    void Shoot() //Disparo derecha
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<control>().animator.SetTrigger("ShootPlayer"); //MOVEMENT STATE

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb2 = arrow.GetComponent<Rigidbody2D>();
        ConstantForce2D force2D = arrow.GetComponent<ConstantForce2D>();
        SpriteRenderer sprite = arrow.GetComponent<SpriteRenderer>();

        force2D.force = new Vector2(50, 0);
        sprite.flipX = false;

        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


    }

    void Shoot2()//Disparo Izquierda
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = arrow.GetComponent<Rigidbody2D>();
        ConstantForce2D force2D = arrow.GetComponent<ConstantForce2D>();
        SpriteRenderer sprite = arrow.GetComponent<SpriteRenderer>();
        force2D.force = new Vector2(-50, 0);
        sprite.flipX = true;
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
