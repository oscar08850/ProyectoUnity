using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class resetScript : MonoBehaviour
{

    public void EmpezarPartida()
    {
        GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().Reiniciar();
        SceneManager.LoadScene(0);
    }


}
