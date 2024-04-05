using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 250;
    public static int rounds;

    public static int lives;
    public int startLives = 10;

    void Start()
    {
        money = startMoney;
        lives = startLives;
        rounds = 0;
    }

    
}
