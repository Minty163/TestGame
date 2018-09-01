using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour {

    //public static int availPickUpCount;
    //public Transform[] availPickUps;
    //private Transform[] availPickUpsTemp;
    //public static List<GameObject> availPickUps { get; set; }
    public static Dictionary<GameResources.Allegiance, List<GameObject>> openPickUpDictionary;
    public static Dictionary<GameResources.Allegiance, List<GameObject>> targetedPickUpDictionary;
    public static Dictionary<GameResources.Allegiance, List<GameObject>> carriedPickUpDictionary;

    public static void AddToOpenPickUp(GameObject PickUp)
    {
        foreach(GameResources.Allegiance allegiance in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            openPickUpDictionary[allegiance].Add(PickUp);
        }
    }

    public static void TargetPickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        openPickUpDictionary[allegiance].Remove(PickUp);
        targetedPickUpDictionary[allegiance].Add(PickUp);
    }

    public static void UntargetPickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        targetedPickUpDictionary[allegiance].Remove(PickUp);
        openPickUpDictionary[allegiance].Add(PickUp);
    }

    public static void CarryPickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        foreach (GameResources.Allegiance item in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            openPickUpDictionary[item].Remove(PickUp);
            targetedPickUpDictionary[item].Remove(PickUp);
        }
        carriedPickUpDictionary[allegiance].Add(PickUp);
    }

    public static void DeliverPickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        carriedPickUpDictionary[allegiance].Remove(PickUp);
    }

    public static bool IsAvailablePickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        return (openPickUpDictionary[allegiance].Contains(PickUp)||targetedPickUpDictionary[allegiance].Contains(PickUp));
    }

}
