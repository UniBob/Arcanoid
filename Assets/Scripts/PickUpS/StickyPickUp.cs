using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPickUp : MonoBehaviour
{
    public int scoreUpdate;


    void AddScore()
    {
        var score = FindObjectOfType<ScoreCounter>();
        score.ScoreUpdate(scoreUpdate);
    }

    void ApplyUpdates(Collider2D collision)
    {
        var balls = FindObjectsOfType<Ball>();
        foreach(Ball tmpBall in balls)
        {
            tmpBall.LockPickUp();
        }
        AddScore();
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
