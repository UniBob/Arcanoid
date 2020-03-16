using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    float minX = -2.4f;
    float maxX = 2.4f;
    float y = -8;
    float z = 0;

    public static bool isPaused = false;

    void Start()
    {
        //set start position to platform
        transform.position = new Vector3(0, y, z);
    }


    // Update is called once per frame
    void Update()
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
}
