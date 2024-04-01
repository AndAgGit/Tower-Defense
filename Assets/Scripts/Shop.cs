using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseRangeTurret()
    {
        Debug.Log("Range Turret Selected");
        buildManager.SetTurretToBuild(buildManager.rangeTurretPrefab);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile Turret Selected");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("Laser Turret Selected");
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab);
    }
}
