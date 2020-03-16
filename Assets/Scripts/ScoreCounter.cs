 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    public LevelData data;
    public Text scoreText;
    public Text lifeText;
    public static int score = 0;
    public static int countsOfBlocks = 0;
    public static int life = 3;
    public int countOfAll;

    void Start()
    {
        score = 0;
        countsOfBlocks = 0;
        life = 3;
        countOfAll = data.level[data.chosenLevel].boxBloksCoordinates.Length + data.level[data.chosenLevel].circleBlocksCoordinates.Length + data.level[data.chosenLevel].triangleBlocksCoordinates.Length;
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
        if (countsOfBlocks == countOfAll) SceneManager.LoadScene(3);
    }
}
