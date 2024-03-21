using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + Mathf.Ceil(WaveSpawner.GetCountdown());
    }
}
