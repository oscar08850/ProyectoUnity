using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJuego : MonoBehaviour
{
    public Vector2 playerPosition = new Vector2 (12,-9);
    public int monedas = 0; // bbdd.monedas???
    public int health = 100; //bbdd.health???
    public int powerFlecha = 40;
    public bool llave1, llave2, llave3, llave4, llave5, llave6;
    public int muertos = 5;

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
            
    }
    

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime ;
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

    public void AddMonedas (int monedas)
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

    public void SetTrue(int llave) {

        if (llave == 1) {
            llave1 = true;
        }
        else if (llave == 2)
        {
            llave2 = true;
        }
        else if (llave == 3)
        {
            llave3 = true;
        }
        else if (llave == 4)
        {
            llave4 = true;
        }
        else if (llave == 5)
        {
            llave5= true;
        }
        else if (llave == 6)
        {
            llave6 = true;
        }
    }

}
