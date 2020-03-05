 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    public static int blocksCount = 1;

    void Start()
    {
        blocksCount--;
        scoreText.text = blocksCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = blocksCount.ToString();
    }
}
