using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class TextToMap : MonoBehaviour
{
    public TextMapping[] mappingData;
    public TextAsset mapText;
    public TextAsset mapText2;
    public Vector2 currentPosition = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
        currentPosition = GameObject.FindGameObjectWithTag("EstadoJuego").GetComponent<EstadoJuego>().GetPlayerPosition();
        char c = '+';
        foreach (TextMapping tm in mappingData)
        {
            if (c == tm.character)
            {
                Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
            }
        }
        GameObject.FindGameObjectWithTag("Coin").GetComponent<ScoreManager>().PintarScore();


    }

    private void GenerateMap()
    {
        string[] rows = Regex.Split(mapText.text, "\r\n|\r|\n");
        string[] filas = Regex.Split(mapText2.text, "\r\n|\r|\n");
        string a = "";
        
        foreach (string row in rows)
        {
            foreach (char c in row)
            {
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
                currentPosition = new Vector2(++currentPosition.x, currentPosition.y);
            }
            currentPosition = new Vector2(0, --currentPosition.y);
        }
        capa2(filas);
    }

    public void capa2(string[] filas)
    {
        char c;
        int i;
        for (i=0; i < filas.Length; i++)
        {
           
            if (filas[i] == "enemigo")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = 'k';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }

            else if (filas[i] == "cartel")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = 'c';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "buzon")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = 'b';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "moneda")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = '&';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "knight")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = '~';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "tinaja")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = 't';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "tinajaRompe")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = 'T';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "barril")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = '¿';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (filas[i] == "barrilRompe")
            {
                currentPosition = new Vector2(System.Convert.ToSingle(filas[i + 1]), System.Convert.ToSingle(filas[i + 2]));
                c = '?';
                foreach (TextMapping tm in mappingData)
                {
                    if (c == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
        }
    }
}

