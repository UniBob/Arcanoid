using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blockStrength = 0;
    public Sprite[] destructionStages;
    public int blockCost;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.countsOfBlocks++;
        this.GetComponent<SpriteRenderer>().sprite = destructionStages[blockStrength];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        blockStrength++;
        if (blockStrength < destructionStages.Length)
        {
            this.GetComponent<SpriteRenderer>().sprite = destructionStages[blockStrength];
        }
        else
        {
            ScoreCounter.score += blockCost;
            ScoreCounter.countsOfBlocks--;
            Destroy(gameObject);
        }
    }
        
}
