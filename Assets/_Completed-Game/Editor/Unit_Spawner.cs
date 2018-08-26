using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Unit_Spawner {

    private Spawner workerSpawner;

    [SetUp]
    public void Setup()
    {
        workerSpawner = new GameObject().AddComponent<Spawner>();
        workerSpawner.Worker = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/_Completed-Game/Prefabs/AllyWorker.prefab", typeof(GameObject));
    }

    [TearDown]
    public void TearDown()
    {
        //GameObject.FindObjectsOfTypeAll(typeof(GameObject));
        //GameObject.FindObjectsOfType<GameObject>();
        foreach(GameObject o in GameObject.FindObjectsOfType<GameObject>())
        {
            //GameObject.Destroy(o);
        }
    }
    /*
    [Test]
    public void Spawn_SpawnsWorkerType() {
        //Arrange

        //Act
        Transform spawnedPrefab = workerSpawner.Spawn();
        //Assert
        Assert.AreEqual(workerSpawner.Worker, spawnedPrefab);
    }

    [Test]
    public void Spawn_InstansiatesAnObject()
    {
        //Arrange

        //Act
        Transform spawnedPrefab = workerSpawner.Spawn();
        //GameObject.Fi
        //Assert
        Assert.AreEqual(new Vector3(0,0,1), new Vector3(0, 0, 1));
    }

    [Test]
    public void Spawn_InstansiatesInCorrectPosition()
    {
        //Arrange

        //Act
        Vector3 spawnedPosition = workerSpawner.Spawn().position;
        //Assert
        Assert.AreEqual(new Vector3(0, 0, 1), spawnedPosition);
    }
    */
    [Test]
    public void Leeearning()
    {
        //Arrange

        //Act
        //Transform x = new GameObject().transform;
        GameObject[] y = GameObject.FindObjectsOfType<GameObject>();
        GameObject playerBall = GameObject.Find("Player");
        //Assert
        Assert.AreEqual(playerBall.transform.position, new Vector3 (0,0,0));
    }

}
