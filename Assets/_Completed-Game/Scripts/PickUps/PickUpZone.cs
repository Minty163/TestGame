using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpZone : MonoBehaviour {

    float Trigger;
    float Min;
    float Max;
    public GameObject Spawn { get; set; }
    //public PickUpHandler pickUpHandler { get; set; }
    public double spawnChance = 0.001f;

    // Use this for initialization
    void Start () {
        Min = 0;
        Max = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Trigger = Random.Range(Min,Max);
        if (Trigger < spawnChance)
        {
            PickUpHandler.AddToAvailPickUps(SpawnPickUp());
        }
	}

    private GameObject SpawnPickUp ()
    {
        return Instantiate(Spawn, new Vector3(this.transform.position.x + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.x), this.transform.position.y, this.transform.position.z + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.z)), Quaternion.identity);
    }

}
