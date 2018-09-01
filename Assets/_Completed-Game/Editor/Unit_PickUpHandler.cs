using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

public class Unit_PickUpHandler {

    private Vector3 targetPosition;
    private GameObject pickUp;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        targetPosition = new Vector3(0, 10, 0);
        pickUp = GameObject.Instantiate(Resources.Load<GameObject>("PickUp"), targetPosition, Quaternion.identity);
    }

    [SetUp]
    public void SetUp()
    {
        PickUpHandler.openPickUpDictionary = new Dictionary<GameResources.Allegiance, List<GameObject>>();
        PickUpHandler.targetedPickUpDictionary = new Dictionary<GameResources.Allegiance, List<GameObject>>();
        PickUpHandler.carriedPickUpDictionary = new Dictionary<GameResources.Allegiance, List<GameObject>>();
        foreach (GameResources.Allegiance item in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            PickUpHandler.openPickUpDictionary.Add(item, new List<GameObject>());
            PickUpHandler.targetedPickUpDictionary.Add(item, new List<GameObject>());
            PickUpHandler.carriedPickUpDictionary.Add(item, new List<GameObject>());
        }
    }

    [Test]
    public void PickUpIsAddedToOpenList()
    {
        //Arrange
        //Act
        PickUpHandler.AddToOpenPickUp(pickUp);
        //Assert
        Assert.Contains(pickUp, PickUpHandler.openPickUpDictionary[GameResources.Allegiance.Team1]);
    }

    [Test]
    public void PickUpIsRemovedFromOpenList()
    {
        //Arrange
        PickUpHandler.AddToOpenPickUp(pickUp);
        //Act
        PickUpHandler.TargetPickUp(pickUp, GameResources.Allegiance.Team1);
        //Assert
        Assert.False(PickUpHandler.openPickUpDictionary[GameResources.Allegiance.Team1].Contains(pickUp));
    }

    [Test]
    public void PickUpIsAddedToTargetedList()
    {
        //Arrange
        PickUpHandler.AddToOpenPickUp(pickUp);
        //Act
        PickUpHandler.TargetPickUp(pickUp, GameResources.Allegiance.Team1);
        //Assert
        Assert.True(PickUpHandler.targetedPickUpDictionary[GameResources.Allegiance.Team1].Contains(pickUp));
    }
}
