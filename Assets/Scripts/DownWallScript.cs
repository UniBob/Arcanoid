using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWallScript : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
       // collision.GetComponent<Ball>();

        var ball = FindObjectOfType<Ball>();
        ball.StopBall();
        ScoreCounter.life--;
        if (ScoreCounter.life == 0) ScoreCounter.countsOfBlocks = 0;
    }

}
