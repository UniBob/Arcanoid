using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int speed;
    bool started = false;
    float deltaY = 1.1f;
    Rigidbody2D rb;
    PlatformScript platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = FindObjectOfType<PlatformScript>();
        rb = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            LockBallToPlatform();
        }
    }

    private void LaunchBall()
    {
        //Vector2 force = new Vector2(speed,speed);
        //rb.AddForce(force);
        rb.velocity = Speed();
    }

    private void LockBallToPlatform()
    {
        transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + deltaY, 0);
        if (Input.GetMouseButtonDown(0))
        {
            started = true;
            LaunchBall();
        }
    }

    public void StopBall()
    {
        rb.velocity = Vector2.zero;
        started = false;
    }

    private Vector2 Speed()
    {
        float tmpSpeed = Random.Range(0, 2*speed) - speed;
        var returnSpeed = new Vector2(tmpSpeed, Mathf.Sqrt(2 * speed * speed - tmpSpeed*tmpSpeed));
        return returnSpeed;
    }
}
