using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[TestFixture]
public class Unit_SpawnerCollision {

    private GameObject mockCollectionZone;
    private GameObject mockSpawner;
    private SpawnerCollision spawnerCollision;
    private Vector3 targetSpawnDirection;
    private int workerCost;
    private List<GameObject> workersToDestroy;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        mockCollectionZone = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("CollectionZone"), new Vector3 (0,0,20), Quaternion.identity);
        mockSpawner = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Spawner"));
        spawnerCollision = mockSpawner.AddComponent<SpawnerCollision>();
        WorkerFactory.WorkerTemplate = Resources.Load<GameObject>("Worker");
        WorkerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        WorkerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        WorkerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
        GameResources.resourceDictionary = new Dictionary<GameResources.Allegiance, int>();
        GameResources.resourceDictionary.Add(GameResources.Allegiance.Team1, 0);
        GameResources.resourceDictionary.Add(GameResources.Allegiance.Team2, 0);
        GameResources.Display = "Resources: ";
        GameResources.DisplayAlt = "Enemy: ";
        GameResources.countText = GameObject.Find("CountText").GetComponent<Text>();
        GameResources.countTextAlt = GameObject.Find("EnemyCountText").GetComponent<Text>();
    }

    [SetUp]
    public void Setup()
    {
        workersToDestroy = new List<GameObject>();
        workerCost = 3;
        targetSpawnDirection = new Vector3(0, 0, 1);
        spawnerCollision.SpawnerCollision_Rebuild(workerCost, Resources.Load<GameObject>("Worker"), mockCollectionZone, targetSpawnDirection, Resources.Load<Material>("Materials/Team1"), GameResources.Allegiance.Team1);
        GameResources.AddResource(9,GameResources.Allegiance.Team1);
    }

    [TearDown]
    public void TearDown()
    {
        GameResources.AddResource(-GameResources.GetResourceCount(GameResources.Allegiance.Team1), GameResources.Allegiance.Team1);
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
        int startResources = GameResources.GetResourceCount(GameResources.Allegiance.Team1);
        //Act
        GameObject newWorker = spawnerCollision.SpawnerCollisionEvent(mockPlayer, targetPosition);
        workersToDestroy.Add(newWorker);
        //Assert
        Assert.AreEqual(startResources - workerCost, GameResources.GetResourceCount(GameResources.Allegiance.Team1));
    }

}
