﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        ScoreManager.scoreManager.RaiseScore(1);

    }

}
