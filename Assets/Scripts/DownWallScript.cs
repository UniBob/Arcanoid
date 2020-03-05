using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWallScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = FindObjectOfType<Ball>();
        ball.StopBall();
    }
}
