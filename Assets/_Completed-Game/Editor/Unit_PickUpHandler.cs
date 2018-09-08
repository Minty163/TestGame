using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

public class Unit_PickUpHandler {

    private Vector3 targetPosition;
    private GameObject pickUp;
    private GameObject worker;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        targetPosition = new Vector3(0, 10, 0);
        pickUp = GameObject.Instantiate(Resources.Load<GameObject>("PickUp"), targetPosition, Quaternion.identity);
        worker = GameObject.Instantiate(Resources.Load<GameObject>("Worker"), targetPosition, Quaternion.identity);
    }

    [SetUp]
    public void SetUp()
    {
        PickUpHandler.openPickUpDictionary = new Dictionary<GameResources.Allegiance, Dictionary<GameObject, GameObject>>();
        //PickUpHandler.targetedPickUpDictionary = new Dictionary<GameResources.Allegiance, Dictionary<GameObject, GameObject>>();
        PickUpHandler.carriedPickUpDictionary = new Dictionary<GameResources.Allegiance, Dictionary<GameObject, GameObject>>();
        foreach (GameResources.Allegiance item in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            PickUpHandler.openPickUpDictionary.Add(item, new Dictionary<GameObject, GameObject>());
            //PickUpHandler.targetedPickUpDictionary.Add(item, new List<GameObject>());
            PickUpHandler.carriedPickUpDictionary.Add(item, new Dictionary<GameObject, GameObject>());
        }
    }

    [Test]
    public void PickUpIsAddedToOpenList()
    {
        //Arrange
        //Act
        PickUpHandler.AddToOpenPickUp(pickUp);
        //Assert
        Assert.True(PickUpHandler.openPickUpDictionary[GameResources.Allegiance.Team1].ContainsKey(pickUp));
    }

    [Test]
    public void PickUpIsRemovedFromOpenList()
    {
        //Arrange
        PickUpHandler.AddToOpenPickUp(pickUp);
        //Act
        PickUpHandler.TargetPickUp(pickUp, worker, GameResources.Allegiance.Team1);
        //Assert
        Assert.False(PickUpHandler.openPickUpDictionary[GameResources.Allegiance.Team1][pickUp] == null);
    }

}
