using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public TMP_Text upgradeCost;
    public Button upgradeButton;

    public TMP_Text sellAmount;

    public void setTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.getBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }

        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
         
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.deselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.deselectNode();
    }
}
