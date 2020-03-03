using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int i = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(i++.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(i.ToString()+" trigger");
    }
}
