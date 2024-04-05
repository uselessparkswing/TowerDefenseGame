using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.canBuild())
        {
            return;
        }

        BuildTurret(buildManager.getTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }
        PlayerStats.money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild())
        {
            return;
        }

        if (buildManager.hasMoney())
        {
            rend.material.color = hoverColor;
        }

        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
