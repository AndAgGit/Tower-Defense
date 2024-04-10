using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public TextMeshProUGUI upgradeText;
    public Button upgradeButton;
    public TextMeshProUGUI sellText;
    public Button sellButton;

    public void SetTarget(Node node)
    {
        target = node;

        transform.position = target.GetBuildPos();
        Hide();

        if (!target.isUpgraded)
        {
            upgradeText.text = "<b>UPGRADE</b>\n$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeText.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellText.text = "<b>SELL</b>\n$" + target.turretBlueprint.Sell;

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
