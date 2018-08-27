using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject worker { get; set; }
    public GameObject collectionZone { get; set; }
    public int workerCost { get; set; }
    public Vector3 spawnDirection { get; set; }
    public GameResources.Allegiance allegiance { get; set; }
    private SpawnerCollision mySpawnerCollision;

    // Use this for initialization
    void Start()
    {
        //mySpawnerCollision = new SpawnerCollision(workerCost, worker, collectionZone, spawnDirection, this.GetComponent<Renderer>().material);
        mySpawnerCollision = this.gameObject.GetComponent<SpawnerCollision>();
        mySpawnerCollision.SpawnerCollision_Rebuild(workerCost, worker, collectionZone, spawnDirection, this.GetComponent<Renderer>().material, allegiance);
        /*
        mySpawnerCollision = this.gameObject.AddComponent<SpawnerCollision>();
        mySpawnerCollision.SpawnerCollision_Rebuild(workerCost, worker, collectionZone, spawnDirection, this.GetComponent<Renderer>().material);
        */
    }

    private void OnCollisionEnter(Collision other)
    {
        mySpawnerCollision.SpawnerCollisionEvent(other.gameObject, this.transform.position);
    }

}
