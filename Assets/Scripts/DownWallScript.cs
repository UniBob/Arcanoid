using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWallScript : MonoBehaviour
{
    //fuction for loosing your lifes
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {            
            var ball = FindObjectOfType<Ball>();
            ball.StopBall();
            var score = FindObjectOfType<ScoreCounter>();
            score.LifeUpdate();
        }
    }
}
