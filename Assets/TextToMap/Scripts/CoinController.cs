using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public ScoreManager scoreManager;
    //GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //ScoreManager.scoreManager.RaiseScore(1);
        //GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().AddMonedas(1);
        //player = GameObject.FindGameObjectWithTag("Player");
        control player = collision.GetComponent<control>();


        if (player != null)
        {
            Destroy(gameObject);
        }
    }

}
