using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJuego : MonoBehaviour
{
    public Vector2 playerPosition = new Vector2 (12,-9);
    public int monedas = 0; // bbdd.monedas???
    public int health = 100; //bbdd.health???
    public int powerFlecha = 40;


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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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




    //PowerFlecha

    public int GetPowerFlecha()
    {
        return this.powerFlecha;
    }

    public void SetPowerFlecha(int powerFlecha)
    {
        this.powerFlecha = powerFlecha;
    }

}
