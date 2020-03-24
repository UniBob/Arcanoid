using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int speed;                   //speed vector length
    public bool started = false;        //cheker of ball move
    float deltaY = 1.1f;                //distance between platform and ball
    Rigidbody2D rb;                     //ball Rigidbody component
    PlatformScript platform;            //link to platform

    // Start is called before the first frame update
    void Start()
    {
        platform = FindObjectOfType<PlatformScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            LockBallToPlatform();
        }
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
        rb.velocity = Speed();
    }

     // lock ball at platform for the start
    private void LockBallToPlatform()
    {
        transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + deltaY, 0);
        if (Input.GetMouseButtonDown(0))
        {
            started = true;
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
}
