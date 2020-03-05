using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.blocksCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreCounter.blocksCount--;
        //this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
