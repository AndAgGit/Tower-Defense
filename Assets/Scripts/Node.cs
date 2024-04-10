using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color tooPoorColor;
    public Vector3 offset;
    public GameObject buildEffect;
    public GameObject upgradeEffect;
    public GameObject sellEffect;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded;

    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
        
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        turretBlueprint = blueprint;

        PlayerStats.money -= blueprint.cost;
        Debug.Log("Turret build! Money left: " + PlayerStats.money);

        GameObject effect = Instantiate(buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 3);

        GameObject tempTurret = Instantiate(blueprint.prefab, GetBuildPos(), Quaternion.identity);
        turret = tempTurret;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money toUpgrade");
            return;
        }

        isUpgraded = true;

        PlayerStats.money -= turretBlueprint.upgradeCost;
        Debug.Log("Turret upgraded! Money left: " + PlayerStats.money);

        // destory old turret
        Destroy(turret);

        // building new one
        GameObject effect = Instantiate(upgradeEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 3);

        GameObject tempTurret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPos(), Quaternion.identity);
        turret = tempTurret;
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.Sell;

        GameObject effect = Instantiate(sellEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 3);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.canBuild)
        {
            return;
        }

        if(buildManager.hasMoney){
            rend.material.color = hoverColor;
        }else{
            rend.material.color = tooPoorColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + offset;
    }
}
