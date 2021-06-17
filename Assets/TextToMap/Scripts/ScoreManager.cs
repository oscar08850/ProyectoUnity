using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    public Text scoreText;
    public Text scoreMuertos;

    public Text scoreTimer;

    public GameObject gameobjectTimer;

    public GameObject gameobject;
    public GameObject gameobjectMuertos;





    private void Start()
    {
        scoreManager = this;

        //MONEDAS
        gameobject = GameObject.FindGameObjectWithTag("ContadorMonedas");
        scoreText = gameobject.GetComponent<Text>();
        scoreText.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetMonedas() + "";
        
        
        //MUERTOS
        gameobjectMuertos = GameObject.FindGameObjectWithTag("ContadorEnemigos");
        scoreMuertos = gameobjectMuertos.GetComponent<Text>();
        scoreMuertos.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetMuertos() + "";


        //TIEMPO

        gameobjectTimer = GameObject.FindGameObjectWithTag("Time");
        scoreTimer = gameobjectTimer.GetComponent<Text>();
        scoreTimer.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetTime() + "";










    }



    public void PintarScore()
    {
        scoreText.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetMonedas() + "";
        scoreMuertos.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetMuertos() + "";
        scoreTimer.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetTime() + "";

    }


}
