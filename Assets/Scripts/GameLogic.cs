using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public LevelData data;                      //link to level database

    public GameObject pauseMenu;                //link to pause elements
    public GameObject pauseButton;              //link to pause button

    public GameObject boxBlock;                 //link to box block prefab
    public GameObject circleBlock;              //link to circle block prefab    
    public GameObject triangleBlock;            //link to triangle block prefab

    public GameObject ball;

    public bool autoPlay = false;
    public float autoPlaySpeed = 1.5f;

    void Start()
    {
        
        //iniciate blocks
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

        Block[] blocks = FindObjectsOfType<Block>();    //array of all blocks on scene

        //iterators on appropriate arrays
        int boxI = 0;
        int circleI = 0;
        int triangleI = 0;

        //set some blocks immune and invisible
        int tmp = data.level[data.chosenLevel].immuneCount;

        var score = FindObjectOfType<ScoreCounter>();
        score.SetCountOfAll(blocks.Length - tmp);

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

        // set count of all blocks
        

        //change positions of blocks
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

        if (autoPlay)
        {
            Time.timeScale = autoPlaySpeed;            
        }

        PowerUpAdd(blocks);
    }


    void PowerUpAdd(Block[] blocks)
    {
        int tmpCount = data.powerUps.Length;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].powerUp = data.powerUps[Random.Range(0, tmpCount)];
        }
    }

    public void AddBall()
    {
        Instantiate(ball);
    }

    // Update is called once per frame
    void Update()
    {
        //pause check
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

    //function for set pause 
    void SetPause(bool pauseStatus)
    {
        PlatformScript.isPaused = pauseStatus;
        if (pauseStatus)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = autoPlay == true ? autoPlaySpeed : 1;
            
        }
        pauseMenu.SetActive(pauseStatus);
        pauseButton.SetActive(!pauseStatus);
    }

    //function for pause button
    public void PauseButton(bool pauseStatus)
    {
        SetPause(pauseStatus);
    }
}
