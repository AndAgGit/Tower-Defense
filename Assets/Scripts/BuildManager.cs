using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject rangeTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }

        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        Debug.Log("Money: " + PlayerStats.money);
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        Debug.Log("Turret build! Money left: " + PlayerStats.money);

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPos(), Quaternion.identity);
        node.turret = turret;
    }
}
