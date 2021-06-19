using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyJoystick;



public class ExitScript : MonoBehaviour
{

    [SerializeField] public Joystick joystick;

    public GameObject key1, key2, key3, key4, key5, key6;

    private void Awake()
    {
        key1 = GameObject.FindGameObjectWithTag("Llave1");
        key2 = GameObject.FindGameObjectWithTag("Llave2");
        key3 = GameObject.FindGameObjectWithTag("Llave3");
        key4 = GameObject.FindGameObjectWithTag("Llave4");
        key5 = GameObject.FindGameObjectWithTag("Llave5");
        key6 = GameObject.FindGameObjectWithTag("Llave6");

    }

    private void Start()
    {
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
        key4.SetActive(false);
        key5.SetActive(false);
        key6.SetActive(false);

        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(1))
            key1.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(2))
            key2.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(3))
            key3.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(4))
            key4.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(5))
            key5.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(6))
            key6.SetActive(true);

    }
    private void Update()
    {
        this.joystick = FindObjectOfType<Joystick>();


        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(1))
            key1.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(2))
            key2.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(3))
            key3.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(4))
            key4.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(5))
            key5.SetActive(true);
        if (GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetKey(6))
            key6.SetActive(true);
    }

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
