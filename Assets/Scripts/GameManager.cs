using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOver;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsOver){
            return;
        }

        if(PlayerStats.lives <= 0){
            EndGame();
        }
    }

    private void EndGame(){
        gameOver.SetActive(true);
        gameIsOver = true;
    }
}
