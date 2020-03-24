﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpeed : MonoBehaviour
{
    public float speedScale;

    void ApplyUpdates(Collider2D collision)
    {
        collision.GetComponent<PlatformScript>().SpeedUpdate(speedScale, speedScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyUpdates(collision);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("GameLose"))
        {
            Destroy(gameObject);
        }
    }
}