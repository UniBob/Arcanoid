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
            var ball = FindObjectsOfType<Ball>();
            if (ball.Length > 1)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                ball[0].ResetSettings();
                var score = FindObjectOfType<ScoreCounter>();
                score.LifeUpdate();
                DeletePickUps();
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void DeletePickUps()
    {
        var tmp = FindObjectsOfType<Rigidbody2D>();
        foreach (var i in tmp)
        {
            if (i.gameObject.CompareTag("PickUp"))
            {
                Destroy(i.gameObject);
            }
        }
    }
}
