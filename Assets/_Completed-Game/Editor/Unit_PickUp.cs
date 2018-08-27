using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class Unit_PickUp {

    private GameObject newPickUpZone;
    private Vector3 targetPosition;
    private List<GameObject> objectsToDestroy;
    private GameObject pickUp;
    private PickUp pickUpInstance;
    private Transform collectorTransform;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        targetPosition = new Vector3(0, 10, 0);
        pickUp = GameObject.Instantiate(Resources.Load<GameObject>("PickUp"), targetPosition, Quaternion.identity);
        pickUpInstance = pickUp.GetComponent<PickUp>();
        collectorTransform = (GameObject.Instantiate(Resources.Load<GameObject>("Worker"), targetPosition, Quaternion.identity)).transform;
    }

    [Test]
    public void PickUpIsPickedUp()
    {
        //Arrange
        pickUpInstance.collected = false;
        //Act
        pickUpInstance.PickedUp(collectorTransform);
        //Assert
        Assert.True(pickUpInstance.collected);
    }

    [Test]
    public void PickUpIsCollectedCheck()
    {
        //Arrange
        pickUpInstance.collected = true;
        //Act
        //Assert
        Assert.True(pickUpInstance.IsCollected());
    }

    [Test]
    public void PickUpIsNotCollectedCheck()
    {
        //Arrange
        pickUpInstance.collected = false;
        //Act
        //Assert
        Assert.False(pickUpInstance.IsCollected());
    }
}
