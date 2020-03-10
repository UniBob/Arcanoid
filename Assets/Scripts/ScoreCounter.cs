 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;
    public static int score = 0;
    public static int countsOfBlocks = 1;
    public static int life = 3;

    void Start()
    {
        scoreText.text = score.ToString();
        countsOfBlocks--;
        lifeText.text = life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
    }
}
