using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour {

    public int availPickUpCount;
    //public Transform[] availPickUps;
    //private Transform[] availPickUpsTemp;
    public List<Transform> availPickUps;

    // Use this for initialization
    void Start ()
    {
        availPickUpCount = 0;
        //availPickUps = new Transform[0];
        //availPickUpsTemp = new Transform[0];
        availPickUps = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Adding new PickUps to be List
    public void AddToAvailPickUps(Transform PickUp)
    {
        availPickUps.Add(PickUp);
        availPickUpCount = availPickUps.Count;
    }

    // Removing new PickUps to be collected
    public void RemoveFromAvailPickUps(Transform PickUp)
    {
        availPickUps.Remove(PickUp);
        availPickUpCount = availPickUps.Count;
    }

    internal bool IsAvailablePickUp(Transform transform)
    {
        return availPickUps.Contains(transform);
    }


    // Adding new PickUps to be collected
    /*
    public void AddToAvailPickUps(Transform PickUp)
    {
        availPickUpsTemp = availPickUps;
        availPickUps = new Transform[availPickUps.Length + 1];
        for (int i = 0; i < availPickUpsTemp.Length; i++)
            availPickUps[i] = availPickUpsTemp[i];
        availPickUps[availPickUpsTemp.Length] = PickUp;
        availPickUpCount = availPickUps.Length;
    }

    // Removing new PickUps to be collected
    public void RemoveFromAvailPickUps(Transform PickUp)
    {
        availPickUpsTemp = availPickUps;
        availPickUps = new Transform[availPickUps.Length - 1];
        int j = 0;
        foreach (Transform item in availPickUpsTemp)
        {
            if (item != PickUp)
            {
                availPickUps[j] = item;
                j = j + 1;
            }
        }
        availPickUpCount = availPickUps.Length;
    }
    */
}
