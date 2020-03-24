using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWidthDown : MonoBehaviour
{
    public float widthScale;

    void ApplyUpdates(Collider2D collision)
    {
        var tmp = collision.transform.localScale;
        tmp.x /= widthScale;
        collision.transform.localScale = tmp;
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
