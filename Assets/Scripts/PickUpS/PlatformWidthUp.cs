using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWidthUp : MonoBehaviour
{
    public float widthScale;
    public int scoreUpdate;

    void AddScore()
    {
        var score = FindObjectOfType<ScoreCounter>();
        score.ScoreUpdate(scoreUpdate);
    }

    void ApplyUpdates(Collider2D collision)
    {
        collision.GetComponent<PlatformScript>().WidthUpdate(widthScale);
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
