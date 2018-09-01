using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
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
