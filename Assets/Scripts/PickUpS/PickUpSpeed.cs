using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpeed : MonoBehaviour
{
    public float speedScale;
    public int scoreUpdate;


    void AddScore()
    {
        var score = FindObjectOfType<ScoreCounter>();
        score.ScoreUpdate(scoreUpdate);
    }

    void ApplyUpdates(Collider2D collision)
    {
        var balls = FindObjectsOfType<Ball>();
        foreach (Ball tmp in balls)
        {
            tmp.SpeedUpdate(speedScale,speedScale);
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

        if (collision.gameObject.CompareTag("GameLose"))
        {
            Destroy(gameObject);
        }
    }
}
