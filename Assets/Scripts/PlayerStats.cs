using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;
    public int startMoney = 30;
    public int startLives = 20;
    public static int rounds;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
        rounds = 0;
    }

    public static int GetMoney()
    {
        return money;
    }

    public static int GetLives()
    {
        return lives;
    }
}
