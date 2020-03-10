using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformScript : MonoBehaviour
{
    float minX = -2.4f;
    float maxX = 2.4f;
    float y = -8;
    float z = 0;

    void Start()
    {
        this.transform.position = new Vector3(0,y,z);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(tmp.x,minX,maxX), y, z);
        if (ScoreCounter.countsOfBlocks == 0) SceneManager.LoadScene(0);
    }
}
