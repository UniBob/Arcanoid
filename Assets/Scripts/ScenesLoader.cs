using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{   
    
    public void Click()
    {
        Debug.Log("Button pressed");
    }

    public void LoadNextLevel()
    {
        int activeSneneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSneneIndex + 1);
    }

    public void LoadlStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
