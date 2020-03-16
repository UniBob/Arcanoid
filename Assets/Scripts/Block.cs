using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blockStrength = 0;
    public Sprite[] destructionStages;      //array of destraction stages
    public int blockCost;                   //cost of block destraction
    public BlockType blockType;             

    public bool isInvisible = false;
    public bool isImmune = false;
    bool tmp = false;                       //need to ignore immune block for cheking for a win
    public enum BlockType
    {
        BOX,
        TRIANGLE,
        CIRCLE
    }

    // Start is called before the first frame update
    void Start()
    {
        //set starting sprites for block
        if (!isInvisible)
        { 
            GetComponent<SpriteRenderer>().sprite = destructionStages[blockStrength]; 
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color (0,0,0,0);
            blockStrength--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //set invisible block visible
        if (isInvisible)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        //ignore damage if block immune
        if (isImmune)
        {
            if (!tmp)
            {
                ScoreCounter.countsOfBlocks++;
                tmp = true;
            }
        }
        //taking damage if it not
        else
        {
            blockStrength++;
            if (blockStrength < destructionStages.Length)
            {
                GetComponent<SpriteRenderer>().sprite = destructionStages[blockStrength];
            }
            else
            {
                ScoreCounter.score += blockCost;
                ScoreCounter.countsOfBlocks++;
                Destroy(gameObject);
            }
        }
    }
        
}
