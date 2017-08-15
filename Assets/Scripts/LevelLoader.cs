using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	private void LoadLevel(Levels level)
    {
        if(level.Equals(Levels.MAIN))
        {
            SceneManager.LoadScene("MainScene");
        }
        else if(level.Equals(Levels.MENU))
        {
            SceneManager.LoadScene("MenuScene");   
        }
    }

    public void LoadMenuScene()
    {
        LoadLevel(Levels.MENU);
    }

    public void LoadMainScene()
    {
        LoadLevel(Levels.MAIN);
    }
}

public enum Levels
{
    MENU, MAIN
}
