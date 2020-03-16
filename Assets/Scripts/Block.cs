using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blockStrength = 0;
    public Sprite[] destructionStages;
    public int blockCost;
    public BlockType blockType;

    public bool isInvisible = false;
    public bool isImmune = false;
    bool tmp = false;
    public enum BlockType
    {
        BOX,
        TRIANGLE,
        CIRCLE
    }

    // Start is called before the first frame update
    void Start()
    {

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
        if (isInvisible)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if (isImmune)
        {
            if (!tmp)
            {
                ScoreCounter.countsOfBlocks++;
                tmp = true;
            }
        }
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
