using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blockStrength = 0;
    public Sprite[] destructionStages;      //array of destraction stages
    public int blockCost;                   //cost of block destraction
    public BlockType blockType;             //type of current block

    public bool isInvisible = false;
    public bool isImmune = false;
   
    ScoreCounter score;                     //link to ScoreCounter on scene

    public GameObject powerUp;

    public enum BlockType                   //block type
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

        score = FindObjectOfType<ScoreCounter>();
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
                score.ScoreUpdateForBlock(blockCost);
                if (powerUp != null)
                {
                    powerUp.transform.position = transform.position;
                    Instantiate(powerUp);
                }
                Destroy(gameObject);
            }
        }
    }


        
}
