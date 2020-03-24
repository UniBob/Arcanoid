using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{
    ScoreCounter score;
    public int LifeCount;

    void ApplyUpdates(Collider2D collision)
    {
        score = FindObjectOfType<ScoreCounter>();
        score.LifeUp(LifeCount);
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
