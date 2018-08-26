using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpZoneFactory : MonoBehaviour {

    public static GameObject PickUpZone { get; set; }
    public static GameObject PickUp { get; set; }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void GiveMePickUpZone(Vector3 targetPosition, Quaternion targetRotation)
    {
        GameObject instance = Instantiate<GameObject>(PickUpZone, targetPosition, targetRotation);
        instance.GetComponent<PickUpZone>().Spawn = PickUp;
        GameObject PickUp1 = Instantiate(PickUp, targetPosition + new Vector3(0, 0, (instance.transform.lossyScale.z * 5)), Quaternion.identity);
        GameObject PickUp2 = Instantiate(PickUp, targetPosition, Quaternion.identity);
        GameObject PickUp3 = Instantiate(PickUp, targetPosition + new Vector3(0, 0, (instance.transform.lossyScale.z * -5)), Quaternion.identity);
        PickUpHandler.AddToAvailPickUps(PickUp1);
        PickUpHandler.AddToAvailPickUps(PickUp2);
        PickUpHandler.AddToAvailPickUps(PickUp3);
    }

}
