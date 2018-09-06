using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawnerCollision : MonoBehaviour {

    private int soldierCost;
    private GameObject soldier;
    private GameResources.Allegiance allegiance;
    private Vector3 spawnDirection;
    private Material myMaterial;
    private Quaternion direction;
    private GameObject aimTarget;

    // Use this for initialization
    void Start()
    {
        //gameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
    }

    public GameObject SoldierSpawnerCollisionEvent(GameObject other, Vector3 position)
    {
        if (other.gameObject.CompareTag("Player") && GameResources.GetResourceCount(allegiance) >= soldierCost)
        {
            foreach(GameObject item in GameObject.FindGameObjectsWithTag("SoldierSpawner"))
            {
                if(item.GetComponent<SoldierSpawner>().Allegiance != allegiance)
                {
                    aimTarget = item;
                    GameObject newSoldier = Spawn(soldier, position);
                    GameResources.AddResource(-soldierCost, allegiance);
                    return newSoldier;
                }
            }
        }
        return other;
    }

    private GameObject Spawn(GameObject gameObject, Vector3 position)
    {
        return SoldierFactory.GiveMeSoldier(position + spawnDirection, direction, allegiance, aimTarget);
    }

    public void SoldierSpawnerCollision_Rebuild(int targetSoldierCost, GameObject targetSoldier, Vector3 targetSpawnDirection, Material targetMaterial, Quaternion targetDirection, GameResources.Allegiance targetAllegience)
    {
        soldierCost = targetSoldierCost;
        soldier = targetSoldier;
        spawnDirection = targetSpawnDirection;
        myMaterial = targetMaterial;
        allegiance = targetAllegience;
        direction = targetDirection;
    }

    public SoldierSpawnerCollision(int targetSoldierCost, GameObject targetSoldier, Vector3 targetSpawnDirection, Material targetMaterial, GameResources.Allegiance targetAllegience)
    {
        soldierCost = targetSoldierCost;
        soldier = targetSoldier;
        spawnDirection = targetSpawnDirection;
        myMaterial = targetMaterial;
        allegiance = targetAllegience;
    }
}
