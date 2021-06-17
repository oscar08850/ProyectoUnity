using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    public Text scoreText;
    public GameObject gameobject;




    private void Start()
    {
        scoreManager = this;

        gameobject = GameObject.FindGameObjectWithTag("ContadorMonedas");

        scoreText = gameobject.GetComponent<Text>();
        scoreText.text = scoreText.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetMonedas() + "";


    }



    public void PintarScore()
    {
        scoreText.text = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetMonedas() + "";
    }


}
