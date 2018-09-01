using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour {

    public GameObject Soldier { get; set; }
    public int SoldierCost { get; set; }
    public Vector3 SpawnDirection { get; set; }
    public GameResources.Allegiance Allegiance { get; set; }
    private SoldierSpawnerCollision mySoldierSpawnerCollision;

    // Use this for initialization
    void Start()
    {
        //mySpawnerCollision = new SpawnerCollision(workerCost, worker, collectionZone, spawnDirection, this.GetComponent<Renderer>().material);
        mySoldierSpawnerCollision = this.gameObject.GetComponent<SoldierSpawnerCollision>();
        mySoldierSpawnerCollision.SoldierSpawnerCollision_Rebuild(SoldierCost, Soldier, SpawnDirection, this.GetComponent<Renderer>().material, Allegiance);
        /*
        mySpawnerCollision = this.gameObject.AddComponent<SpawnerCollision>();
        mySpawnerCollision.SpawnerCollision_Rebuild(workerCost, worker, collectionZone, spawnDirection, this.GetComponent<Renderer>().material);
        */
    }

    private void OnCollisionEnter(Collision other)
    {
        mySoldierSpawnerCollision.SoldierSpawnerCollisionEvent(other.gameObject, this.transform.position);
    }
}
