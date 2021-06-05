using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

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
        foreach (string fila in filas)
        {
            a = a + fila;
            int i;
            string[] palabra = Regex.Split(a, "\r\n|\r|\n");
            char q;
            if (palabra[1] == "jugador")
            {
                currentPosition = new Vector2(5, 5);
                q = '+';
                foreach (TextMapping tm in mappingData)
                {
                    if (q == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
            else if (palabra[6] == "buzon")
            {
                q = 'b';
                foreach (TextMapping tm in mappingData)
                {
                    if (q == tm.character)
                    {
                        Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                    }
                }
            }
        }
        
    }
}
