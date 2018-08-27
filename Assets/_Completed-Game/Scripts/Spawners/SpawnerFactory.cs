using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFactory : MonoBehaviour {

    public static GameObject Spawner { get; set; }
    public static GameObject WorkerTemplate { get; set; }
    public static GameResources GameResources { get; set; }
    public static int WorkerCost { get; set; }
    //public static Vector3 SpawnDirection { get; set; }
    public static Material Team1Material { get; set; }
    public static Material Team2Material { get; set; }
    public static Material DefaultMaterial { get; set; }

    public static GameObject GiveMeSpawner(Vector3 targetPosition, Quaternion targetRotation, GameResources.Allegiance allegiance, GameObject collectionZone, Vector3 spawnDirection)
    {
        GameObject instance = Instantiate<GameObject>(Spawner, targetPosition, targetRotation);
        instance.GetComponent<Spawner>().worker = WorkerTemplate;
        instance.GetComponent<Spawner>().collectionZone = collectionZone;
        instance.GetComponent<Spawner>().gameResources = GameResources;
        instance.GetComponent<Spawner>().workerCost = WorkerCost;
        instance.GetComponent<Spawner>().spawnDirection = spawnDirection;
        instance.GetComponent<Spawner>().allegiance = allegiance;
        switch(allegiance)
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
