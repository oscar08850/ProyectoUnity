using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarcaScript : MonoBehaviour
{
    Vector2 playerPosition = new Vector2(0, 0);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetTrip())
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetPlayerPosition(playerPosition = new Vector2(12, -14));
            SceneManager.LoadScene(1);
        }
    }
}
