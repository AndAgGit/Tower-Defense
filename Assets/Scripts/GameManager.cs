using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOver;
    public GameObject gameWin;

    public string nextLevel = "Level 2";
    public int levelToUnlock = 2;
    public SceneFader fader;

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

    public void WinLevel()
    {
        Debug.Log("Level Win");
        gameWin.SetActive(true);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
