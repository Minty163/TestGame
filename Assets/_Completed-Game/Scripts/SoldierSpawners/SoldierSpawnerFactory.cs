using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawnerFactory : MonoBehaviour {

    public static GameObject SoldierSpawner { get; set; }
    public static GameObject SoldierTemplate { get; set; }
    public static int SoldierCost { get; set; }
    public static Material Team1Material { get; set; }
    public static Material Team2Material { get; set; }
    public static Material DefaultMaterial { get; set; }

    public static GameObject GiveMeSoldierSpawner(Vector3 targetPosition, Quaternion targetRotation, GameResources.Allegiance allegiance, Vector3 spawnDirection)
    {
        GameObject instance = Instantiate<GameObject>(SoldierSpawner, targetPosition, targetRotation);
        instance.GetComponent<SoldierSpawner>().Soldier = SoldierTemplate;
        instance.GetComponent<SoldierSpawner>().SoldierCost = SoldierCost;
        instance.GetComponent<SoldierSpawner>().SpawnDirection = spawnDirection;
        instance.GetComponent<SoldierSpawner>().Allegiance = allegiance;
        switch (allegiance)
        {
            case GameResources.Allegiance.Team1:
                instance.GetComponent<Renderer>().material = Team1Material;
                break;
            case GameResources.Allegiance.Team2:
                instance.GetComponent<Renderer>().material = Team2Material;
                break;
            default:
                instance.GetComponent<Renderer>().material = DefaultMaterial;
                break;
        }
        return instance;
    }
}
