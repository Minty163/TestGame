using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCollision : MonoBehaviour {

    private GameResources gameResources;
    private int workerCost;
    private GameObject worker;
    private GameObject collectionZone;
    private GameResources.Allegiance allegiance;
    private Vector3 spawnDirection;
    private Material myMaterial;

    // Use this for initialization
    void Start () {
        //gameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
    }
	
    public GameObject SpawnerCollisionEvent(GameObject other, Vector3 position)
    {
        if (other.gameObject.CompareTag("Player") && gameResources.GetResourceCount() >= workerCost)
        {
            GameObject newWorker = Spawn(worker, position);
            gameResources.AddResource(-workerCost);
            return newWorker;
        }
        return other;
    }

    private GameObject Spawn(GameObject gameObject, Vector3 position)
    {
        return WorkerFactory.GiveMeWorker(position + spawnDirection, Quaternion.identity, allegiance, collectionZone);

        //GameObject createdWorker = Instantiate(gameObject, position + spawnDirection, Quaternion.identity);
        //createdWorker.GetComponent<Renderer>().material = myMaterial;
        //Worker workerObject = createdWorker.GetComponent<Worker>();
        //workerObject.SetHomeZone(collectionZone);
        //workerObject.SetAllegiance(allegiance);
        //workerObject.SetGameResources(gameResources);
        //return createdWorker;
    }

    public void SpawnerCollision_Rebuild(int targetWorkerCost, GameObject targetWorker, GameObject targetCollectionZone, Vector3 targetSpawnDirection, Material targetMaterial, GameResources.Allegiance targetAllegience)
    {
        workerCost = targetWorkerCost;
        worker = targetWorker;
        collectionZone = targetCollectionZone;
        spawnDirection = targetSpawnDirection;
        myMaterial = targetMaterial;
        allegiance = targetAllegience;
        gameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
    }

    public SpawnerCollision(int targetWorkerCost, GameObject targetWorker, GameObject targetCollectionZone, Vector3 targetSpawnDirection, Material targetMaterial, GameResources.Allegiance targetAllegience)
    {
        workerCost = targetWorkerCost;
        worker = targetWorker;
        collectionZone = targetCollectionZone;
        spawnDirection = targetSpawnDirection;
        myMaterial = targetMaterial;
        allegiance = targetAllegience;
        gameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
    }

}
