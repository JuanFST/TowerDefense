using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint stabdardTurret;
    public TurretBlueprint MissileTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectedStandardTurret()
    {
        Debug.Log("standard selected");
        buildManager.SelectTurretToBuild(stabdardTurret);
    }
    public void SelectedMissileTurret()
    {
        Debug.Log("Missile selected");
        buildManager.SelectTurretToBuild(MissileTurret);

    }

}
