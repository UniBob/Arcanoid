﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeUp : MonoBehaviour
{
    public float sizeScale;

    void ApplyUpdates(Collider2D collision)
    {
        var balls = FindObjectsOfType<Ball>();
        foreach(Ball tmp in balls)
        {
            tmp.BallSizeUp(sizeScale);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyUpdates(collision);
            Destroy(gameObject);
        }
    }
}
