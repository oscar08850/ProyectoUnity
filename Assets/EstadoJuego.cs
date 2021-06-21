using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJuego : MonoBehaviour
{

#if UNITY_ANDROID

AndroidJavaClass UnityPlayer;


AndroidJavaObject currentActivity;


AndroidJavaObject intent;


#endif


public Vector2 playerPosition = new Vector2(12, -9);
    public int monedas = 0; // bbdd.monedas???
    public int maxHealth = 100; //bbdd.MAXHEALTH
    public int health = 100; //bbdd.health???

    public int pocimaAzul = 0; //BaseDatos
    public int pocimaRoja = 0; //BaseDatos
    public int manzana = 0; //BaseDatos
    private bool bossMuerto = false;

    public int powerFlecha = 40;
    public bool llave1, llave2, llave3, llave4, llave5, llave6;
    public int muertos = 0;

    

    public GameObject key1, key2, key3, key4, key5, key6;

    public float tiempo = 0.0f;
    public int tiempoContador = 0;


    public static EstadoJuego estadoJuego;


    void Awake()

    {

        Debug.Log("Dentro del AWAKE ESTADO JUEGO");
        if (estadoJuego == null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (estadoJuego != this)
        {
            Destroy(gameObject);
        }

        ///

#if UNITY_ANDROID

        UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        if (UnityPlayer == null) {
            Debug.Log("UnityPlayer Null");
        }
        else
            Debug.Log("UnityPlayer not Null");


        
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        if (currentActivity == null)
        {
            Debug.Log("currentActivity Null");
        }
        else
            Debug.Log("currentActivity not Null");


        intent = currentActivity.Call<AndroidJavaObject>("getIntent");
        if (intent == null)
        {
            Debug.Log("intent Null");
        }
        else
            Debug.Log("intent not Null");

        //string text = intent.Call<string>("getStringExtra", "varName");


        //AndroidJavaObject extras = intent.Call<AndroidJavaObject>("GetExtras");

        this.pocimaAzul = intent.Call<int>("getIntExtra", "pocionAzul",-69);
        this.pocimaRoja = intent.Call<int>("getIntExtra", "pocionRoja",-69);
        this.manzana = intent.Call<int>("getIntExtra", "manzana",-69);

        this.maxHealth = intent.Call<int>("getIntExtra", "maxHealth", -69);
        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Healthbar>().SetMaxHealth(this.maxHealth);

        this.powerFlecha = intent.Call<int>("getIntExtra", "powerFlecha", -69);
        Debug.Log("pocima azul " + this.pocimaAzul + "pocima roja " + this.pocimaRoja + "manzana " + this.manzana);

#endif


        ///
        this.health = maxHealth;

        key1 = GameObject.FindGameObjectWithTag("Llave1");
        key2 = GameObject.FindGameObjectWithTag("Llave2");
        key3 = GameObject.FindGameObjectWithTag("Llave3");
        key4 = GameObject.FindGameObjectWithTag("Llave4");
        key5 = GameObject.FindGameObjectWithTag("Llave5");
        key6 = GameObject.FindGameObjectWithTag("Llave6");

    }



    private void FixedUpdate()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();           
            }
        }
    }

    private void Start()
    {
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
        key4.SetActive(false);
        key5.SetActive(false);
        key6.SetActive(false);

        
        if (llave1)
            key1.SetActive(true);
        if (llave2)
            key2.SetActive(true);
        if (llave3)
            key3.SetActive(true);
        if (llave4)
            key4.SetActive(true);
        if (llave5)
            key5.SetActive(true);
        if (llave6)
            key6.SetActive(true);

    }

    public void BossMuerto()
    {
        this.bossMuerto = true;
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
        if (bossMuerto = false || health > 0)
        {
            tiempo += Time.deltaTime;
            tiempoContador = (int)tiempo;
        }

        if (llave1)
            key1.SetActive(true);
        if (llave2)
            key2.SetActive(true);
        if (llave3)
            key3.SetActive(true);
        if (llave4)
            key4.SetActive(true);
        if (llave5)
            key5.SetActive(true);
        if (llave6)
            key6.SetActive(true);
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

    //Fuerza
    public int getFuerza() {
        return powerFlecha;
    }



    //Muertos

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

    public void PocimaAzul()
    {
        if (this.pocimaAzul > 0)
        {
            this.health = maxHealth;
            this.pocimaAzul--;

            //IF (this.pocimaAzul == 0)   ELSE BUTTON DISABLED

        }



        //Devolver a la base datos PocimaAzul--

    }

    public void PocimaRoja()
    {
        if (this.pocimaRoja > 0)
        {
            this.health = 75;
            this.pocimaRoja--;

            //IF (this.pocimaRoja == 0)   ELSE BUTTON DISABLED

        }



        //Devolver a la base datos PocimaAzul--

    }

    public void Manzana()
    {
        if (this.manzana > 0)
        {
            this.health = this.health + 20;
            if (this.health > maxHealth)
            {
                this.health = maxHealth;
            }
            this.manzana--;

            //IF (this.manzana == 0)   ELSE BUTTON DISABLED

        }



        //Devolver a la base datos PocimaAzul--

    }

    public int GetPocionRoja()
    {
        return this.pocimaRoja;
    }

    public int GetPocionAzul()
    {
        return this.pocimaAzul;
    }

    public int GetManzana()
    {
        return this.manzana;
    }

    public void Reiniciar()
    {
        this.health = maxHealth;
        this.tiempo = 0.0f;
        this.tiempoContador = 0;
        this.monedas = 0;
        this.muertos = 0;
        this.llave1 = false;
        this.llave2 = false;
        this.llave3 = false;
        this.llave4 = false;
        this.llave5 = false;
        this.llave6 = false;
    }


    public void enviar(){
        currentActivity.Call("onGameFinish", monedas, muertos, tiempoContador);
    }

    public void enviarPocionRoja()
    {
        currentActivity.Call("onGamePocionRoja", "pocionRoja");
    }

    public void enviarPocionAzul()
    {
        currentActivity.Call("onGamePocionAzul", "PocionAzul");
    }

    public void enviarManzana ()
    {
        currentActivity.Call("onGameManzana", "manzana");
    }






    public void enviarMonedas() {
        currentActivity.Call("onGameMonedas", monedas);

    }

}