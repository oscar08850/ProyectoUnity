using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TextToMap : MonoBehaviour
{
    public TextMapping[] mappingData;
    public TextAsset mapText;

    public Vector2 currentPosition = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        string[] rows = Regex.Split(mapText.text, "\r\n|\r|\n");
        int i = 0;

        foreach (string row in rows)
        {
            if (i == 0)
            {
                foreach (char c in row)
                {
                    foreach (TextMapping tm in mappingData)
                    {
                        if (c == tm.character)
                        {

                            if (c.Equals('+'))
                            {
                                i = 1;
                            }
                            else
                            {
                                Instantiate(tm.prefab, currentPosition, Quaternion.identity, transform);
                            }
                        }
                    }
                    currentPosition = new Vector2(++currentPosition.x, currentPosition.y);
                }
                currentPosition = new Vector2(0, --currentPosition.y);
            }
            else
            {
                int j = 0;
                string[] fila = row.Split(',');
                if (fila[0] == "jugador")
                {
                    char c = '+';

                    foreach (TextMapping tm in mappingData)
                    {
                        if (c == tm.character)
                        {
                            Vector2 currentPosition2 = new Vector2(System.Convert.ToSingle(fila[1]), System.Convert.ToSingle(fila[2]));
                            Instantiate(tm.prefab, currentPosition2, Quaternion.identity, transform);
                            j = 1;

                        }
                        else { }
                    }

                }
                else if (fila[0] == "buzon")
                {
                    char c = 'b';
                    string texto = fila[3];
                    while (j == 0)
                    {
                        foreach (TextMapping tm in mappingData)
                        {
                            if (c == tm.character)
                            {
                                Vector2 currentPosition2 = new Vector2(System.Convert.ToSingle(fila[1]), System.Convert.ToSingle(fila[2]));
                                Instantiate(tm.prefab, currentPosition2, Quaternion.identity, transform);
                            }
                        }
                    }
                }
                else if (fila[0] == "baul")
                {
                    char c = 'B';
                    string elementos = "";
                    for (int k = 3; k < fila.Length; k++)
                    {
                        elementos = elementos + fila[k] + ",";
                    }
                    foreach (TextMapping tm in mappingData)
                    {
                        if (c == tm.character)
                        {
                            Vector2 currentPosition2 = new Vector2(System.Convert.ToSingle(fila[1]), System.Convert.ToSingle(fila[2]));
                            Instantiate(tm.prefab, currentPosition2, Quaternion.identity, transform);
                        }
                    }
                }
                else if (fila[0] == "cartel")
                {
                    char c = 'c';
                    string texto = fila[3];
                    foreach (TextMapping tm in mappingData)
                    {
                        if (c == tm.character)
                        {
                            Vector2 currentPosition2 = new Vector2(System.Convert.ToSingle(fila[1]), System.Convert.ToSingle(fila[2]));
                            Instantiate(tm.prefab, currentPosition2, Quaternion.identity, transform);
                        }
                        else { }
                    }

                }
                else
                {
                    char c = 'm';
                    foreach (TextMapping tm in mappingData)
                    {
                        if (c == tm.character)
                        {
                            Vector2 currentPosition2 = new Vector2(System.Convert.ToSingle(fila[1]), System.Convert.ToSingle(fila[2]));
                            Instantiate(tm.prefab, currentPosition2, Quaternion.identity, transform);
                        }
                    }
                }
            }
        }
    }
}
