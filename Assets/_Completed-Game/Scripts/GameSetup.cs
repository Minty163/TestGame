using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {


    // Use this for initialization
    void Start () {
        //PickUps
        PickUpHandler.availPickUps = new List<GameObject>();
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
        SpawnerFactory.GameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
        SpawnerFactory.WorkerCost = 3;
        SpawnerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        SpawnerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        SpawnerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
        //Worker
        WorkerFactory.WorkerTemplate = Resources.Load<GameObject>("Worker");
        WorkerFactory.GameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
        WorkerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        WorkerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        WorkerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");

        //Team1CollectionZone
        GameObject team1CollectionZone = CollectionZoneFactory.GiveMeCollectionZone(new Vector3(-8, 0.01f, -27), Quaternion.identity, GameResources.Allegiance.Team1);
        //Team1Spawner
        SpawnerFactory.GiveMeSpawner(new Vector3(-4, 0.5f, -27), Quaternion.identity, GameResources.Allegiance.Team1, team1CollectionZone, new Vector3(0, 0, 1));
        //Team2CollectionZone
        GameObject team2CollectionZone = CollectionZoneFactory.GiveMeCollectionZone(new Vector3(-8, 0.01f, 27), Quaternion.identity, GameResources.Allegiance.Team2);
        //Team2Spawner
        SpawnerFactory.GiveMeSpawner(new Vector3(-4, 0.5f, 27), Quaternion.identity, GameResources.Allegiance.Team2, team2CollectionZone, new Vector3(0, 0, -1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}