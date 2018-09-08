using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour {

    //public static int availPickUpCount;
    //public Transform[] availPickUps;
    //private Transform[] availPickUpsTemp;
    //public static List<GameObject> availPickUps { get; set; }

    //Team, PickUp, Worker
    //public static Dictionary<GameResources.Allegiance, List<GameObject>> openPickUpDictionary;
    public static Dictionary<GameResources.Allegiance, Dictionary<GameObject, GameObject>> openPickUpDictionary;
    //public static Dictionary<GameResources.Allegiance, List<GameObject>> targetedPickUpDictionary;
    //public static Dictionary<GameResources.Allegiance, Dictionary<GameObject, GameObject>> targetedPickUpDictionary;
    //public static Dictionary<GameResources.Allegiance, List<GameObject>> carriedPickUpDictionary;
    public static Dictionary<GameResources.Allegiance, Dictionary<GameObject, GameObject>> carriedPickUpDictionary;

    public static void AddToOpenPickUp(GameObject PickUp)
    {
        foreach(GameResources.Allegiance allegiance in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            openPickUpDictionary[allegiance].Add(PickUp, null);
        }
    }

    public static void TargetPickUp(GameObject PickUp, GameObject Worker, GameResources.Allegiance allegiance)
    {
        openPickUpDictionary[allegiance][PickUp] = Worker;
        //openPickUpDictionary[allegiance].Remove(PickUp);
        //targetedPickUpDictionary[allegiance].Add(PickUp, Worker);
    }
    
    public static void UntargetPickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        //targetedPickUpDictionary[allegiance].Remove(PickUp);
        //openPickUpDictionary[allegiance].Add(PickUp, null);
        openPickUpDictionary[allegiance][PickUp] = null;
    }
    
    public static void CarryPickUp(GameObject PickUp, GameObject Worker, GameResources.Allegiance allegiance)
    {
        foreach (GameResources.Allegiance item in Enum.GetValues(typeof(GameResources.Allegiance)))
        {
            if(openPickUpDictionary[item][PickUp] != null)
            {
                openPickUpDictionary[item][PickUp].GetComponent<Worker>().ClearTarget();
            }
            openPickUpDictionary[item].Remove(PickUp);
            //targetedPickUpDictionary[item].Remove(PickUp);
        }
        carriedPickUpDictionary[allegiance].Add(PickUp, Worker);
    }

    public static void DeliverPickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        carriedPickUpDictionary[allegiance].Remove(PickUp);
    }

    public static bool IsAvailablePickUp(GameObject PickUp, GameResources.Allegiance allegiance)
    {
        return openPickUpDictionary[allegiance].ContainsKey(PickUp);
        /*
        if (openPickUpDictionary[allegiance].ContainsKey(PickUp))
        {
            return true;
        }
        return false;
        */
    }

}
