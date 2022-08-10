using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("error mmas de una instancia en la escena");
        }
        instance = this;

    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money>= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("No hay dinero suficiente");
            return;

        }
        PlayerStats.money -= turretToBuild.cost;

        GameObject turret =(GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("torreta contruida, queda: " + PlayerStats.money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
