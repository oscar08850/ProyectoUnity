using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TextMapping
{
    public char character;
    public GameObject prefab;

    public void setCharacter(char c)
    {
        this.character = c;
    }
}
