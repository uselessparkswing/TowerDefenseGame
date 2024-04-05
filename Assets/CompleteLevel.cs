using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int nextLevelIndex = 2;

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", nextLevelIndex);
        sceneFader.FadeTo(nextLevel);
    }
}
