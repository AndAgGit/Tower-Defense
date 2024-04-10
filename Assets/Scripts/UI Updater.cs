using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public static UIUpdater instance;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public Camera mainCam;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "TIME\n" + WaveSpawner.GetCountdownCiel();
        moneyText.text = "MONEY\n$" + PlayerStats.GetMoney();
        livesText.text = "LIVES : " + PlayerStats.GetLives(); 
    }
}
