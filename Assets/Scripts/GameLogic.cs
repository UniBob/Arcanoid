using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public LevelData data;
    //public BlockData data;
    public GameObject boxBlock;
    public GameObject circleBlock;
    public GameObject triangleBlock;
    void Start()
    {
        for (int i = 0;i<data.level[data.chosenLevel].boxBloksCoordinates.Length;i++)
        {
            Instantiate(boxBlock);
        }
        for (int i = 0; i < data.level[data.chosenLevel].circleBlocksCoordinates.Length; i++)
        {
            Instantiate(circleBlock);
        }

        for (int i = 0; i < data.level[data.chosenLevel].triangleBlocksCoordinates.Length; i++)
        {
            Instantiate(triangleBlock);
        }
        Block[] blocks = FindObjectsOfType<Block>();
        Debug.Log(blocks.Length.ToString());
        int boxI = 0;
        int circleI = 0;
        int triangleI = 0;
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].blockType == Block.BlockType.BOX)
            {
                blocks[i].transform.position = data.level[data.chosenLevel].boxBloksCoordinates[boxI];
                boxI++;
            }
            if (blocks[i].blockType == Block.BlockType.TRIANGLE)
            {
                blocks[i].transform.position = data.level[data.chosenLevel].triangleBlocksCoordinates[triangleI];
                triangleI++;
            }
            if (blocks[i].blockType == Block.BlockType.CIRCLE)
            {
                blocks[i].transform.position = data.level[data.chosenLevel].circleBlocksCoordinates[circleI];
                circleI++;
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
