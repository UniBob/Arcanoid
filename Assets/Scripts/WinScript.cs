using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public Text congratulateText;
    [TextArea(minLines: 1, maxLines: 10)] public string text;
    // Start is called before the first frame update
    void Start()
    {
        congratulateText.text = text + ScoreCounter.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
