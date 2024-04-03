using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        timeText.text = "TIME\n" + WaveSpawner.GetCountdownCiel();
        moneyText.text = "MONEY\n$" + PlayerStats.GetMoney();
    }
}
