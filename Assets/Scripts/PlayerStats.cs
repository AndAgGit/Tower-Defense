using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;
    public int startMoney = 30;
    public int startLives = 20;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
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
