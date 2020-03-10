 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public static int countsOfBlocks = 1;

    void Start()
    {
        scoreText.text = score.ToString();
        countsOfBlocks--;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
       
    }
}
