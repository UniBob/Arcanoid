using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPickUp : MonoBehaviour
{
    void ApplyUpdates(Collider2D collision)
    {
        var balls = FindObjectsOfType<Ball>();
        foreach(Ball tmpBall in balls)
        {
            tmpBall.LockPickUp();
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
