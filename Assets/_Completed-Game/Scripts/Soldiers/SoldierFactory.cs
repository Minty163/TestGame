using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : MonoBehaviour {

    public static GameObject SoldierTemplate { get; set; }
    public static Material Team1Material { get; set; }
    public static Material Team2Material { get; set; }
    public static Material DefaultMaterial { get; set; }

    public static GameObject GiveMeSoldier(Vector3 targetPosition, Quaternion targetRotation, GameResources.Allegiance allegiance, GameObject target)
    {
        GameObject instance = Instantiate<GameObject>(SoldierTemplate, targetPosition, targetRotation);
        instance.GetComponent<Soldier>().allegiance = allegiance;
        instance.GetComponent<Soldier>().aimTarget = target;
        switch (allegiance)
        {
            case GameResources.Allegiance.Team1:
                instance.GetComponent<Renderer>().material = Team1Material;
                instance.transform.GetChild(0).GetComponent<Renderer>().material = Team1Material;
                instance.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Team1Material;
                break;
            case GameResources.Allegiance.Team2:
                instance.GetComponent<Renderer>().material = Team2Material;
                instance.transform.GetChild(0).GetComponent<Renderer>().material = Team2Material;
                instance.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Team2Material;
                break;
            default:
                instance.GetComponent<Renderer>().material = DefaultMaterial;
                instance.transform.GetChild(0).GetComponent<Renderer>().material = DefaultMaterial;
                instance.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = DefaultMaterial;
                break;
        }
        return instance;
    }
}
