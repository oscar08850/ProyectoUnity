using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;

    public Text scoreText;
    public GameObject gameobject;


    int score = 0;

    private void Start()
    {
        scoreManager = this;
        //player = GameObject.FindGameObjectWithTag("Player");
        //scoreText = scoreText.GetComponent<Text>();

        gameobject = GameObject.FindGameObjectWithTag("ContadorMonedas");
        scoreText = gameobject.GetComponent<Text>();

    }

    private void Update()
    {
        Debug.Log("ESTO ES: gameobject " + gameobject);
        Debug.Log("HELLO");

        Debug.Log("ESTO ES: TEXT " + scoreText.GetComponent<Text>());

    }

    public void RaiseScore(int s)
    {
        score += s;
        scoreText.text = score + "";
        Debug.Log(score);
    }


}
