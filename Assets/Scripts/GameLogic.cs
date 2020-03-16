using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public LevelData data;

    public GameObject pauseMenu;
    public GameObject pauseButton;

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

        int tmp = data.level[data.chosenLevel].immuneCount;
        while (tmp>0)
        {
            int a = Random.Range(0, blocks.Length);
            if (!blocks[a].isImmune)
            { 
                blocks[a].isImmune = true;
                tmp--;
            }
        }

        tmp = data.level[data.chosenLevel].invisibleCount;
        while (tmp > 0)
        {
            int a = Random.Range(0, blocks.Length);
            if (!blocks[a].isInvisible)
            {
                blocks[a].isInvisible = true;
                tmp--;
            }
        }

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
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlatformScript.isPaused)
            {
                SetPause(false);
            }
            else
            {
                SetPause(true);
            }
        }

    }

    void SetPause(bool pauseStatus)
    {
        PlatformScript.isPaused = pauseStatus;
        if (pauseStatus)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        pauseMenu.active = pauseStatus;
        pauseButton.active = !pauseStatus;
    }

    public void PauseButton(bool pauseStatus)
    {
        SetPause(pauseStatus);
    }
}
