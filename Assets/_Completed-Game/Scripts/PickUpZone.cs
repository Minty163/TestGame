using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpZone : MonoBehaviour {

    float Trigger;
    public Transform Spawn;
    GameScope gameScope;
    public float spawnChance = 0.001f;

    // Use this for initialization
    void Start () {
        gameScope = GameObject.Find("GameScope").GetComponent<GameScope>();
        Transform PickUp1 = (Transform)Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (this.transform.lossyScale.z * 5.0f)), Quaternion.identity);
        Transform PickUp2 = (Transform)Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Transform PickUp3 = (Transform)Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (this.transform.lossyScale.z * 5.0f)), Quaternion.identity);
        gameScope.AddToAvailPickUps(PickUp1);
        gameScope.AddToAvailPickUps(PickUp2);
        gameScope.AddToAvailPickUps(PickUp3);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Trigger = Random.Range(0.0f, 1.0f);
        if (Trigger < spawnChance)
        {
            //Transform aPickUp = (Transform)Instantiate(Spawn, new Vector3(this.transform.position.x + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.x), this.transform.position.y, this.transform.position.z + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.z)), Quaternion.identity);
            //global.AddToAvailPickUps(aPickUp);
            gameScope.AddToAvailPickUps(SpawnPickUp());
            //global.AddToAvailPickUps((Transform)Instantiate(Spawn, new Vector3(this.transform.position.x + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.x), this.transform.position.y, this.transform.position.z + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.z)), Quaternion.identity));
        }
	}

    private Transform SpawnPickUp ()
    {
        return (Transform)Instantiate(Spawn, new Vector3(this.transform.position.x + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.x), this.transform.position.y, this.transform.position.z + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.z)), Quaternion.identity);
    }
}
