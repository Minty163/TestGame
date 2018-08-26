using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {


    // Use this for initialization
    void Start () {
        PickUpHandler.availPickUps = new List<GameObject>();
        PickUpZoneFactory.PickUpZone = Resources.Load<GameObject>("PickUpZone");
        PickUpZoneFactory.PickUp = Resources.Load<GameObject>("PickUp");
        PickUpZoneFactory.GiveMePickUpZone(new Vector3(-6, 0.5f, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
