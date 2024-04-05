using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager instance in scene!");
        }

        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool canBuild() { return turretToBuild != null; }

    public bool hasMoney() { return PlayerStats.money >= turretToBuild.cost; }

    public void selectNode(Node node)
    {
        if (selectedNode == node)
        {
            deselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.setTarget(node);
    }

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        deselectNode();
    }

    public void deselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint getTurretToBuild()
    {
        return turretToBuild;
    }
}
