using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    float minX = -2.4f;             //far left position of platform 
    float maxX = 2.4f;              //far right position of platform
    float y = -8;                   //current y-coordinate
    float z = 0;                    //current z-coordinate

    public static bool isPaused = false;        //pause status

    GameLogic gl;
    Ball ball;

    void Start()
    {
        gl = FindObjectOfType<GameLogic>();
        ball = FindObjectOfType<Ball>();

        //set start position to platform
        transform.position = new Vector3(0, y, z);
    }


    public void SpeedUpdate(float x, float y)
    {
        ball.SpeedUpdate(x,y);
    }

    // Update is called once per frame
    void Update()
    {
        if (gl.autoPlay & ball.GetStarted())
        {
            MoveWithBall();
        }
        else
        {
            MoveWithMouse();
        }
    }

    void MoveWithMouse()
    {
        if (isPaused)
        {
            //if game is paused platfaorm not moving   
        }
        else
        {
            //moving the platform by mouse if game isn't pause
            Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Clamp(tmp.x, minX, maxX), y, z);
        }
    }

    void MoveWithBall()
    {
        transform.position = new Vector3(ball.transform.position.x, y, z);
    }

    public void WidthUpdate(float widthScale)
    {
        var tmp = transform.localScale;
        tmp.x *= widthScale;
        transform.localScale = tmp;
    }

    
}
