 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    public LevelData data;                      //link to level data    
    public Text scoreText;                      //link to score text
    public Text lifeText;                       //link to life text
    public static int score = 0;                //current score
    public static int countsOfBlocks = 0;       //current count of blocks on current scene
    public static int life = 3;                 //current lifes
    public int countOfAll = 1;                  //count of all blocks on scene at start

    void Start()
    {
        score = 0;                                  
        countsOfBlocks = 0;
        life = 3;
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
    }

    //update score counter and text on scene
    public void ScoreUpdate(int blockCost)
    {        
        score += blockCost;
        countsOfBlocks++;
        scoreText.text = score.ToString();
        if (countsOfBlocks >= countOfAll) SceneManager.LoadScene(3);
    }

    //update life counter and text on scene
    public void LifeUpdate()
    {
        life--;
        lifeText.text = life.ToString();
        if (life <= 0) SceneManager.LoadScene(3);
    }

    //function to set count of blocks at start
    //used at block script
    public void SetCountOfAll(int count)
    {
        countOfAll = count;
    }
}
