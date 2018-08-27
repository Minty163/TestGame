using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerFactory : MonoBehaviour {

    public static GameObject WorkerTemplate { get; set; }
    public static GameResources GameResources { get; set; }
    public static Material Team1Material { get; set; }
    public static Material Team2Material { get; set; }
    public static Material DefaultMaterial { get; set; }

    public static GameObject GiveMeWorker(Vector3 targetPosition, Quaternion targetRotation, GameResources.Allegiance allegiance, GameObject collectionZone)
    {
        GameObject instance = Instantiate<GameObject>(WorkerTemplate, targetPosition, targetRotation);
        instance.GetComponent<Worker>().HomeZone = collectionZone;
        instance.GetComponent<Worker>().gameResources = GameResources;
        instance.GetComponent<Worker>().allegiance = allegiance;
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
