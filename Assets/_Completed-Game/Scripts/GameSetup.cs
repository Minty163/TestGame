using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour {


    // Use this for initialization
    void Start () {
        //GameResources
        GameResources.resourceDictionary = new Dictionary<GameResources.Allegiance, int>();
        GameResources.resourceDictionary.Add(GameResources.Allegiance.Team1, 0);
        GameResources.resourceDictionary.Add(GameResources.Allegiance.Team2, 0);
        GameResources.Display = "Resources: ";
        GameResources.DisplayAlt = "Enemy: ";
        GameResources.countText = GameObject.Find("CountText").GetComponent<Text>();
        GameResources.countTextAlt = GameObject.Find("EnemyCountText").GetComponent<Text>();
        GameResources.SetResourceText(GameResources.Allegiance.Team1);
        GameResources.SetResourceText(GameResources.Allegiance.Team2);
        //PickUps
        PickUpHandler.openPickUpDictionary = new Dictionary<GameResources.Allegiance, List<GameObject>>();
        PickUpHandler.targetedPickUpDictionary = new Dictionary<GameResources.Allegiance, List<GameObject>>();
        PickUpHandler.carriedPickUpDictionary = new Dictionary<GameResources.Allegiance, List<GameObject>>();
        foreach (GameResources.Allegiance item in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            PickUpHandler.openPickUpDictionary.Add(item, new List<GameObject>());
            PickUpHandler.targetedPickUpDictionary.Add(item, new List<GameObject>());
            PickUpHandler.carriedPickUpDictionary.Add(item, new List<GameObject>());
        }
        PickUpZoneFactory.PickUpZone = Resources.Load<GameObject>("PickUpZone");
        PickUpZoneFactory.PickUp = Resources.Load<GameObject>("PickUp");
        PickUpZoneFactory.GiveMePickUpZone(new Vector3(-6, 0.5f, 0), Quaternion.identity);
        //CollectionZone
        CollectionZoneFactory.CollectionZone = Resources.Load<GameObject>("CollectionZone");
        CollectionZoneFactory.Team1Material = Resources.Load<Material>("Materials/Team1Alt");
        CollectionZoneFactory.Team2Material = Resources.Load<Material>("Materials/Team2Alt");
        CollectionZoneFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
        //Spawner
        SpawnerFactory.Spawner = Resources.Load<GameObject>("Spawner");
        SpawnerFactory.WorkerTemplate = Resources.Load<GameObject>("Worker");
        SpawnerFactory.WorkerCost = 0;
        SpawnerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        SpawnerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        SpawnerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
        //Worker
        WorkerFactory.WorkerTemplate = Resources.Load<GameObject>("Worker");
        WorkerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        WorkerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        WorkerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
        //SoldierSpawner
        SoldierSpawnerFactory.SoldierSpawner = Resources.Load<GameObject>("SoldierSpawner");
        SoldierSpawnerFactory.SoldierTemplate = Resources.Load<GameObject>("Soldiers/Soldier1");
        SoldierSpawnerFactory.SoldierCost = 0;
        SoldierSpawnerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        SoldierSpawnerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        SoldierSpawnerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
        //Soldier
        SoldierFactory.SoldierTemplate = Resources.Load<GameObject>("Soldiers/Soldier1");
        SoldierFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        SoldierFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        SoldierFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");

        //Team1CollectionZone
        GameObject team1CollectionZone = CollectionZoneFactory.GiveMeCollectionZone(new Vector3(-8, 0.01f, -27), Quaternion.identity, GameResources.Allegiance.Team1);
        //Team1Spawner
        SpawnerFactory.GiveMeSpawner(new Vector3(-4, 0.5f, -27), Quaternion.identity, GameResources.Allegiance.Team1, team1CollectionZone, new Vector3(0, 0, 1));
        //Team1SoldierSpawner
        SoldierSpawnerFactory.GiveMeSoldierSpawner(new Vector3(6, 0.5f, -27), Quaternion.identity, GameResources.Allegiance.Team1, new Vector3(0, 0, 1));

        //Team2CollectionZone
        GameObject team2CollectionZone = CollectionZoneFactory.GiveMeCollectionZone(new Vector3(-8, 0.01f, 27), Quaternion.identity, GameResources.Allegiance.Team2);
        //Team2Spawner
        SpawnerFactory.GiveMeSpawner(new Vector3(-4, 0.5f, 27), Quaternion.identity, GameResources.Allegiance.Team2, team2CollectionZone, new Vector3(0, 0, -1));
        //Team2SoldierSpawner
        SoldierSpawnerFactory.GiveMeSoldierSpawner(new Vector3(6, 0.5f, 27), Quaternion.identity, GameResources.Allegiance.Team2, new Vector3(0, 0, -1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}