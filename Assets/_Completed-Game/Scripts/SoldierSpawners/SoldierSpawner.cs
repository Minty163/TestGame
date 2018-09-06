using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour {

    public GameObject Soldier { get; set; }
    public int SoldierCost { get; set; }
    public Vector3 SpawnDirection { get; set; }
    public GameResources.Allegiance Allegiance { get; set; }
    public int Health { get; set; }
    private SoldierSpawnerCollision mySoldierSpawnerCollision;

    // Use this for initialization
    void Start()
    {
        mySoldierSpawnerCollision = this.gameObject.GetComponent<SoldierSpawnerCollision>();
        mySoldierSpawnerCollision.SoldierSpawnerCollision_Rebuild(SoldierCost, Soldier, this.transform.rotation * SpawnDirection, this.GetComponent<Renderer>().material, this.transform.rotation, Allegiance);
        Health = 100;
    }

    private void OnCollisionEnter(Collision other)
    {
        mySoldierSpawnerCollision.SoldierSpawnerCollisionEvent(other.gameObject, this.transform.position);
    }
}
