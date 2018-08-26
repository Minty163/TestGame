using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlaySpawner {

    private GameObject playerBall;
    private GameObject workerSpawner;

    [SetUp]
    public void Setup()
    {
        //((GameObject)AssetDatabase.LoadAssetAtPath("Assets/_Completed-Game/Prefabs/AllyWorker.prefab", typeof(GameObject))).transform;
        //Transform createdWorker = Object.Instantiate(cube, new Vector3 (0,0,0), Quaternion.identity);
        //playerBall = GameObject.Find("Player");
        //workerSpawner = GameObject.Find("AllyWorkerSpawner");
        //workerSpawner.Worker = ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/_Completed-Game/Prefabs/AllyWorker.prefab", typeof(GameObject))).transform;
        GameObject.Instantiate(Resources.Load<GameObject>("Ground"));
        //GameObject[] y = GameObject.FindObjectsOfType<GameObject>();
        //GameObject playerBall = GameObject.Find("Player");
        //int z = y.Length;
    }

    [TearDown]
    public void TearDown()
    {
        //GameObject.FindObjectsOfTypeAll(typeof(GameObject));
        //GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject o in GameObject.FindObjectsOfType<GameObject>())
        {
            //GameObject.Destroy(o);
        }
    }

    [UnityTest]
    public IEnumerator Leeearning()
    {
        //Arrange

        //Act
        //Transform x = new GameObject().transform;
        GameObject[] y = GameObject.FindObjectsOfType<GameObject>();
        GameObject playerBall = GameObject.Find("Player");
        int z = y.Length;
        //Assert
        Assert.AreEqual(playerBall.transform.position, new Vector3(0, 0, 0));
        yield return null;
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator SpawnerWithEnumeratorPasses() {
        //Arrange
        //playerBall.transform.position = workerSpawner.transform.position + new Vector3 (2,0,0);
        //Act
        //playerBall.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * playerBall.GetComponent<PlayerController>().speed);
        //Assert
        
        // yield to skip a frame
        yield return null;
    }
}
