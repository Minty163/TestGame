using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class Unit_SpawnerCollision {

    private GameObject mockCollectionZone;
    private GameObject mockSpawner;
    private SpawnerCollision spawnerCollision;
    private Vector3 targetSpawnDirection;
    private int workerCost;
    private GameResources gameResources;
    private List<GameObject> workersToDestroy;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        mockCollectionZone = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("CollectionZone"), new Vector3 (0,0,20), Quaternion.identity);
        mockSpawner = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Spawner"));
        spawnerCollision = mockSpawner.AddComponent<SpawnerCollision>();
        gameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
        WorkerFactory.WorkerTemplate = Resources.Load<GameObject>("Worker");
        WorkerFactory.GameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
        WorkerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        WorkerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        WorkerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
    }

    [SetUp]
    public void Setup()
    {
        workersToDestroy = new List<GameObject>();
        workerCost = 3;
        targetSpawnDirection = new Vector3(0, 0, 1);
        spawnerCollision.SpawnerCollision_Rebuild(workerCost, Resources.Load<GameObject>("Worker"), mockCollectionZone, targetSpawnDirection, Resources.Load<Material>("Materials/Team1"), GameResources.Allegiance.Team1);
        gameResources.AddResource(9);
    }

    [TearDown]
    public void TearDown()
    {
        gameResources.AddResource(-gameResources.GetResourceCount());
        foreach(GameObject o in workersToDestroy)
        {
            GameObject.DestroyImmediate(o);
        }
    }
 
    [Test]
    public void WorkerIsSpawned()
    {
        //Arrange
        GameObject mockPlayer = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Player"));
        Vector3 targetPosition = new Vector3(0,10,0);
        //Act
        GameObject newWorker = spawnerCollision.SpawnerCollisionEvent(mockPlayer, targetPosition);
        workersToDestroy.Add(newWorker);
        //Assert
        Assert.AreEqual("Worker", newWorker.tag);
    }

    [Test]
    public void WorkerIsSpawnedInCorrectPlace()
    {
        //Arrange
        GameObject mockPlayer = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Player"));
        Vector3 targetPosition = new Vector3(0, 10, 0);
        //Act
        GameObject newWorker = spawnerCollision.SpawnerCollisionEvent(mockPlayer, targetPosition);
        workersToDestroy.Add(newWorker);
        //Assert
        Assert.AreEqual(targetPosition + targetSpawnDirection, newWorker.transform.position); //1 further in the z direction from 
    }

    [Test]
    public void WorkerCostsResources()
    {
        //Arrange
        GameObject mockPlayer = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Player"));
        Vector3 targetPosition = new Vector3(0, 10, 0);
        int startResources = gameResources.GetResourceCount();
        //Act
        GameObject newWorker = spawnerCollision.SpawnerCollisionEvent(mockPlayer, targetPosition);
        workersToDestroy.Add(newWorker);
        //Assert
        Assert.AreEqual(startResources - workerCost, gameResources.GetResourceCount());
    }

}
