using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class Unit_SpawnerFactory {

    private GameObject mockCollectionZone;
    private GameObject newSpawner;
    private Vector3 targetPosition;
    private List<GameObject> objectsToDestroy;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        mockCollectionZone = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("CollectionZone"), new Vector3(0, 0, 20), Quaternion.identity);
        targetPosition = new Vector3(0, 10, 0);
        SpawnerFactory.Spawner = Resources.Load<GameObject>("Spawner");
        SpawnerFactory.WorkerTemplate = Resources.Load<GameObject>("Worker");
        SpawnerFactory.GameResources = GameObject.Find("AllyResources").GetComponent<GameResources>();
        SpawnerFactory.WorkerCost = 3;
        SpawnerFactory.Team1Material = Resources.Load<Material>("Materials/Team1");
        SpawnerFactory.Team2Material = Resources.Load<Material>("Materials/Team2");
        SpawnerFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
    }
    
    [SetUp]
    public void Setup()
    {
        objectsToDestroy = new List<GameObject>();
    }
    
    [TearDown]
    public void TearDown()
    {
        foreach (GameObject o in objectsToDestroy)
        {
            GameObject.DestroyImmediate(o);
        }
    }

    [Test]
    public void SpawnerIsCreated() {
        //Arrange
        //Act
        GameObject newSpawner = SpawnerFactory.GiveMeSpawner(targetPosition, Quaternion.identity,GameResources.Allegiance.Team1, mockCollectionZone, new Vector3(0, 0, 1));
        objectsToDestroy.Add(newSpawner);
        //Assert
        Assert.AreEqual("Spawner", newSpawner.tag);
    }

    [Test]
    public void SpawnerIsCreatedInCorrectPlace()
    {
        //Arrange
        //Act
        GameObject newSpawner = SpawnerFactory.GiveMeSpawner(targetPosition, Quaternion.identity, GameResources.Allegiance.Team1, mockCollectionZone, new Vector3(0, 0, 1));
        //Assert
        Assert.AreEqual(targetPosition, newSpawner.transform.position);
    }

}
