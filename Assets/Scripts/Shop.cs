using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint standard;
    public TurretBlueprint range;
    public TurretBlueprint missile;
    public TurretBlueprint laser;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standard);
    }

    public void SelectRangeTurret()
    {
        Debug.Log("Range Turret Selected");
        buildManager.SelectTurretToBuild(range);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret Selected");
        buildManager.SelectTurretToBuild(missile);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("Laser Turret Selected");
        buildManager.SelectTurretToBuild(laser);
    }
}
