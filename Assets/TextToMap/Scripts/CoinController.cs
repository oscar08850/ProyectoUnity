﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public ScoreManager scoreManager;
    //GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        control player = collision.GetComponent<control>();


        if (player != null)
        {
            Destroy(gameObject);
        }
    }

}
