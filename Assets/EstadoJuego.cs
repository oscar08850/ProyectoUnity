using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJuego : MonoBehaviour
{
    public Vector2 playerPosition = new Vector2(12, -9);
    public int monedas = 0; // bbdd.monedas???
    public int health = 100; //bbdd.health???
    public int powerFlecha = 40;
    public bool llave1, llave2, llave3, llave4, llave5, llave6, lasNinasBonitasNoPaganDinero;
    public int muertos = 5;

    public GameObject key1, key2, key3, key4, key5, key6;

    public float tiempo = 0.0f;
    public int tiempoContador = 0;


    public static EstadoJuego estadoJuego;


    void Awake()
    {
        if (estadoJuego == null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (estadoJuego != this)
        {
            Destroy(gameObject);
        }

        key1 = GameObject.FindGameObjectWithTag("Llave1");
        key2 = GameObject.FindGameObjectWithTag("Llave2");
        key3 = GameObject.FindGameObjectWithTag("Llave3");
        key4 = GameObject.FindGameObjectWithTag("Llave4");
        key5 = GameObject.FindGameObjectWithTag("Llave5");
        key6 = GameObject.FindGameObjectWithTag("Llave6");

    }

    private void Start()
    {
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
        key4.SetActive(false);
        key5.SetActive(false);
        key6.SetActive(false);

        /*
        if (llave1)
            key1.SetActive(true);
        if (llave2)
            key2.SetActive(true);
        */
        if (llave3)
            key1.SetActive(true);
        if (llave4)
            key4.SetActive(true);
        if (llave5)
            key5.SetActive(true);
        if (llave6)
            key6.SetActive(true);

    }

    public bool GetKey(int numero)
    {
        switch (numero)
        {
            case 1:
                return llave1;
                break;
            case 2:
                return llave2;
                break;
            case 3:
                return llave3;
                break;
            case 4:
                return llave4;
                break;
            case 5:
                return llave5;
                break;
            case 6:
                return llave6;
                break;
            default:
                return false;
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        tiempoContador = (int)tiempo;
    }


    //Posicion
    public Vector2 GetPlayerPosition()
    {
        return playerPosition;
    }
    public void SetPlayerPosition(Vector2 playerPosition)
    {
        this.playerPosition = playerPosition;
    }


    //Monedas

    public int GetMonedas()
    {
        return this.monedas;
    }

    public void AddMonedas(int monedas)
    {
        this.monedas = this.monedas + monedas;
    }


    //Monedas

    public int GetMuertos()
    {
        return this.muertos;
    }

    public void AddMuertos(int muertos)
    {
        this.muertos = this.muertos + muertos;
    }



    //Vida

    public int GetHealth()
    {
        return this.health;
    }

    public int SetHealthDamage(int damage)
    {
        this.health = this.health - damage;
        return this.health;
    }


    //Tiempo
    public float GetTime()
    {
        return this.tiempoContador;
    }



    //PowerFlecha

    public int GetPowerFlecha()
    {
        return this.powerFlecha;
    }

    public void SetPowerFlecha(int powerFlecha)
    {
        this.powerFlecha = powerFlecha;
    }



    //Llaves

    public void SetTrue(int llave)
    {

        if (llave == 1)
        {
            llave1 = true;
            key1.SetActive(true);

        }
        else if (llave == 2)
        {
            llave2 = true;
            key2.SetActive(true);

        }
        else if (llave == 3)
        {
            llave3 = true;
            key3.SetActive(true);

        }
        else if (llave == 4)
        {
            llave4 = true;
            key4.SetActive(true);

        }
        else if (llave == 5)
        {
            llave5 = true;
            key5.SetActive(true);

        }
        else if (llave == 6)
        {
            llave6 = true;
            key6.SetActive(true);
        }


    }

    public bool GetTrip()
    {
        if (llave1 && llave2 && llave3 && llave4 && llave5 && llave6)
        {
            return true;
        }
        else
            return false;
    }

}