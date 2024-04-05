using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded =  false;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    public string nextLevel = "Level02";
    public int nextLevelIndex = 2;

    void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameEnded = true;
        completeLevelUI.SetActive(true);
    }
}
