using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
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
        PickUpHandler.availPickUps = new List<GameObject>();
    }

    [Test]
    public void PickUpIsAddedToList()
    {
        //Arrange
        //Act
        PickUpHandler.AddToAvailPickUps(pickUp);
        //Assert
        Assert.Contains(pickUp, PickUpHandler.availPickUps);
    }

    [Test]
    public void PickUpIsRemovedFromList()
    {
        //Arrange
        PickUpHandler.availPickUps.Add(pickUp);
        //Act
        PickUpHandler.RemoveFromAvailPickUps(pickUp);
        //Assert
        Assert.False(PickUpHandler.availPickUps.Contains(pickUp));
        //Assert.Equals(0, pickUpCount);
    }
}
