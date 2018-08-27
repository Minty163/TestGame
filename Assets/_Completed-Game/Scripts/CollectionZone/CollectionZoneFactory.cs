using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionZoneFactory : MonoBehaviour {

    public static GameObject CollectionZone { get; set; }
    public static Material Team1Material { get; set; }
    public static Material Team2Material { get; set; }
    public static Material DefaultMaterial { get; set; }

    public static GameObject GiveMeCollectionZone(Vector3 targetPosition, Quaternion targetRotation, GameResources.Allegiance allegiance)
    {
        GameObject instance = Instantiate<GameObject>(CollectionZone, targetPosition, targetRotation);
        switch (allegiance)
        {
            case GameResources.Allegiance.Team1:
                instance.GetComponent<Renderer>().material = Team1Material;
                break;
            case GameResources.Allegiance.Team2:
                instance.GetComponent<Renderer>().material = Team2Material;
                break;
            default:
                instance.GetComponent<Renderer>().material = DefaultMaterial;
                break;
        }
        return instance;
    }
}
