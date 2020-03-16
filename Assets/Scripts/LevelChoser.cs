using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoser : MonoBehaviour
{
    public LevelData data;

    //function for set level and load game scene
    public void LevelChoosing(int i)
    {
        data.chosenLevel = i;          
        SceneManager.LoadScene(2);
    }
}
