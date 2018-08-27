using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class Unit_PickUpZoneFactory {

    private GameObject newPickUpZone;
    private Vector3 targetPosition;
    private List<GameObject> objectsToDestroy;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        targetPosition = new Vector3(0, 10, 0);
        PickUpHandler.availPickUps = new List<GameObject>();
        PickUpZoneFactory.PickUpZone = Resources.Load<GameObject>("PickUpZone");
        PickUpZoneFactory.PickUp = Resources.Load<GameObject>("PickUp");
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
    public void PickUpZoneIsCreated()
    {
        //Arrange
        //Act
        GameObject newPickUpZone = PickUpZoneFactory.GiveMePickUpZone(targetPosition, Quaternion.identity);
        objectsToDestroy.Add(newPickUpZone);
        //Assert
        Assert.AreEqual("PickUpZone", newPickUpZone.tag);
    }

    [Test]
    public void PickUpZoneIsCreatedInCorrectPlace()
    {
        //Arrange
        //Act
        GameObject newPickUpZone = PickUpZoneFactory.GiveMePickUpZone(targetPosition, Quaternion.identity);
        objectsToDestroy.Add(newPickUpZone);
        //Assert
        Assert.AreEqual(targetPosition, newPickUpZone.transform.position);
    }
}
