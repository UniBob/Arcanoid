using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    GameLogic game;
    public int scoreUpdate;
    
    void AddScore()
    {
        var score = FindObjectOfType<ScoreCounter>();
        score.ScoreUpdate(scoreUpdate);
    }

    void ApplyUpdates(Collider2D collision)
    {
        var ball = FindObjectOfType<Ball>();
        Ball tmp = Instantiate(ball);
        tmp.LaunchNewBall();
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
