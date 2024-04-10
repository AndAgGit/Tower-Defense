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
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool canBuild { get { return turretToBuild != null && hasMoney; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }
    public void SelectNode(Node node)
    {
        if(selectedNode  == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        Debug.Log("Money: " + PlayerStats.money);
        turretToBuild = turret;

        DeselectNode();
    }

    public void BuildTurretOn(Node node)
    {
        
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
