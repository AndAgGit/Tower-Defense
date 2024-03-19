using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + Mathf.Ceil(WaveSpawner.GetCountdown());
    }
}
