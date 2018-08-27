using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class Unit_CollectionZoneFactory {

    private GameObject newCollectionZone;
    private Vector3 targetPosition;
    private List<GameObject> objectsToDestroy;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        targetPosition = new Vector3(0, 10, 0);
        CollectionZoneFactory.CollectionZone = Resources.Load<GameObject>("CollectionZone");
        CollectionZoneFactory.Team1Material = Resources.Load<Material>("Materials/Team1Alt");
        CollectionZoneFactory.Team2Material = Resources.Load<Material>("Materials/Team2Alt");
        CollectionZoneFactory.DefaultMaterial = Resources.Load<Material>("Materials/Default");
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
        newCollectionZone = CollectionZoneFactory.GiveMeCollectionZone(targetPosition, Quaternion.identity, GameResources.Allegiance.Team1);
        objectsToDestroy.Add(newCollectionZone);
        //Assert
        Assert.AreEqual("CollectionZone", newCollectionZone.tag);
    }

    [Test]
    public void PickUpZoneIsCreatedInCorrectPlace()
    {
        //Arrange
        //Act
        newCollectionZone = CollectionZoneFactory.GiveMeCollectionZone(targetPosition, Quaternion.identity, GameResources.Allegiance.Team1);
        objectsToDestroy.Add(newCollectionZone);
        //Assert
        Assert.AreEqual(targetPosition, newCollectionZone.transform.position);
    }
}
