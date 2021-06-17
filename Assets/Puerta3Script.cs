using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta3Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 playerPosition = new Vector2(0, 0);
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetPlayerPosition(playerPosition = new Vector2(17, -9));
            SceneManager.LoadScene(4);
        }
    }
}
