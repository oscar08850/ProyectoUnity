using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 playerPosition = new Vector2(0, 0);
        
        if (collision.gameObject.tag == "Player")
        {
            if (SceneManager.GetSceneByName("Casa1").isLoaded == true)
            {
                GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetPlayerPosition(playerPosition = new Vector2(43, -13));
                SceneManager.LoadScene(0);
            }
            else if (SceneManager.GetSceneByName("Casa2").isLoaded == true)
            {
                GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetPlayerPosition(playerPosition = new Vector2(54, -20));
                SceneManager.LoadScene(0);
            }
            else
            {
                GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().SetPlayerPosition(playerPosition = new Vector2(65, -13));
                SceneManager.LoadScene(0);
            }
            
            
        }
    }

}
