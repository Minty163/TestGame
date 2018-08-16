using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpZone : MonoBehaviour {

    float Trigger;
    public Transform Spawn;

	// Use this for initialization
	void Start () {
        Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (this.transform.lossyScale.z * 5.0f)), Quaternion.identity);
        Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (this.transform.lossyScale.z * 5.0f)), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Instantiate(Spawn, new Vector3(this.transform.position.x + Random.Range(-1, 1), this.transform.position.y, this.transform.position.z + Random.Range(-1, 1)), Quaternion.identity);
        Trigger = Random.Range(0.0f, 1.0f);
        if (Trigger > 0.999f)
        {
            Instantiate(Spawn, new Vector3(this.transform.position.x + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.x), this.transform.position.y, this.transform.position.z + (Random.Range(-5.0f, 5.0f) * this.transform.lossyScale.z)), Quaternion.identity);
        }
	}
}
