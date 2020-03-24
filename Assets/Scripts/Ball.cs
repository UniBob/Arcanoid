using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int speed;                   //speed vector length
    public bool started;                //cheker of ball move
    float deltaY = 1.1f;                //distance between platform and ball
    Rigidbody2D rb;                     //ball Rigidbody component
    PlatformScript platform;            //link to platform

    public bool isStiky = false;
    Vector3 deltaPosition;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        platform = FindObjectOfType<PlatformScript>();
        transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + deltaY, 0);
        deltaPosition = transform.position - platform.transform.position;
        deltaPosition.y = deltaY;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            LockBallToPlatform();
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
    }

    public void SpeedUpdate(float x, float y)
    {
        Vector2 deltaSpeed = rb.velocity;
        deltaSpeed.x *= x;
        deltaSpeed.y *= y;
        rb.velocity += deltaSpeed;
    }

    public bool GetStarted()
    {
        return started;
    }


    //let ball to start
    private void LaunchBall()
    {
        started = true;
        rb.velocity = Speed();
    }

     // lock ball at platform for the start
    private void LockBallToPlatform()
    {
        transform.position = platform.transform.position + deltaPosition;
        if (Input.GetMouseButtonDown(0))
        {            
            LaunchBall();
        }
    }

    //stop ball at all
    public void StopBall()
    {
        rb.velocity = Vector2.zero;
        started = false;
    }

    //give speed with random x and y, but always same vector
    private Vector2 Speed()
    {
        float tmpSpeed = Random.Range(0, 2*speed) - speed;
        var returnSpeed = new Vector2(tmpSpeed, Mathf.Sqrt(2 * speed * speed - tmpSpeed*tmpSpeed));
        return returnSpeed;
    }

    public void BallSizeUp(float update)
    {
        transform.localScale *= update;
    }

    public void LockPickUp()
    {
        isStiky = true;
        timer = Time.time;
    }


    public void LaunchNewBall()
    {
        LaunchBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Platform")) && (isStiky))
        {
            deltaPosition = transform.position - platform.transform.position;
            deltaPosition.y = deltaY;
            started = false;
            LockBallToPlatform();
            if (Time.time - timer > 5)
            {
                isStiky = false;
            }
        }
    }
}
