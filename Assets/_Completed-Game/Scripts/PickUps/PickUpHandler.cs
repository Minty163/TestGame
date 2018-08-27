using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour {

    public static int availPickUpCount;
    //public Transform[] availPickUps;
    //private Transform[] availPickUpsTemp;
    public static List<GameObject> availPickUps { get; set; }

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Adding new PickUps to be List
    public static void AddToAvailPickUps(GameObject PickUp)
    {
        availPickUps.Add(PickUp);
        availPickUpCount = availPickUps.Count;
    }

    // Removing new PickUps to be collected
    public static void RemoveFromAvailPickUps(GameObject PickUp)
    {
        availPickUps.Remove(PickUp);
        availPickUpCount = availPickUps.Count;
    }

    internal static bool IsAvailablePickUp(GameObject gameObject)
    {
        return availPickUps.Contains(gameObject);
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
