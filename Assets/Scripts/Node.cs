using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color tooPoorColor;
    public Vector3 offset;
    public GameObject buildEffect;

    [Header("Optional")]
    public GameObject turret;

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

        if (!buildManager.canBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Occupied");
            return;
        }

        buildManager.BuildTurretOn(this);
        GameObject effect = Instantiate(buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 3);
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
