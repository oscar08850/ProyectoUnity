using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarInfoBotonesScript : MonoBehaviour
{
    public GameObject EstadoJuego;

    public int pocimaAzul = 0; //BaseDatos
    public int pocimaRoja = 0; //BaseDatos
    public int manzana = 0; //BaseDatos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pocimaRoja = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetPocionRoja();
        pocimaAzul = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetPocionAzul();
        manzana = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetManzana();

    }




    public void PocimaAzul()
    {
        if (this.pocimaAzul > 0)
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().PocimaAzul();
        }
    }

    public void PocimaRoja()
    {
        if (this.pocimaRoja > 0)
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().PocimaRoja();
        }

    }

    public void Manzana()
    {
        if (this.manzana > 0)
        {
            GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().Manzana();
        }
    }
}
