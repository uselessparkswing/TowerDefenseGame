using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    public TMP_Text standardTurretItem;
    public TMP_Text missileLauncherItem;
    public TMP_Text laserBeamerItem;

    void Start()
    {
        buildManager = BuildManager.instance;
        standardTurretItem.text = "$" + standardTurret.cost;
        missileLauncherItem.text = "$" + missileLauncher.cost;
        laserBeamerItem.text = "$" + laserBeamer.cost;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");

        buildManager.selectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");

        buildManager.selectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.selectTurretToBuild(laserBeamer);
    }
}
