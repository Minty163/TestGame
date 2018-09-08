using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {

    public float speed;
    bool atCapacity;
    GameObject cargo;
    PickUpHandler pickUpHandler;
    public GameObject HomeZone { get; set; }
    GameObject aimTarget;
    public GameResources.Allegiance allegiance { get; set; }


    // Use this for initialization
    void Start () {
        atCapacity = false;
        aimTarget = null;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!atCapacity)
        {
            //if (aimTarget.Equals(null))
            if (aimTarget == null)
            {
                //Debug.Log("CollectionZoneTarget");
                //find direction to closest pick up
                //List<GameObject> AllPickUps = PickUpHandler.openPickUpDictionary[allegiance];
                GameObject Target = TargetClosestPickUp();
                //PickUpHandler.TargetPickUp(Target, this.gameObject, allegiance);
                aimTarget = Target;
            }
        }

        MoveToTarget(aimTarget);

        //Normalize Rotate
        GetComponent<Rigidbody>().AddRelativeTorque(-1 * this.transform.rotation.x, -1 * this.transform.rotation.y, -1 * this.transform.rotation.z);
        //GetComponent<Rigidbody>().AddForce(0.0f, speed * Mathf.Max(Mathf.Min(0.5f - this.transform.position.y, 10), -10), 0.0f);
        GetComponent<Rigidbody>().AddForce(0.0f, speed * (0.5f - this.transform.position.y), 0.0f);
        //GetComponent<Rigidbody>().AddForce()

    }

    public void ClearTarget()
    {
        aimTarget = null;
    }

    private void MoveToTarget(GameObject Target)
    {
        if(Target == null) { Target = HomeZone; }
        Vector3 movement = (Target.transform.position - transform.position);
        movement = new Vector3(movement.x, 0.0f, movement.z);
        movement.Normalize();
        GetComponent<Rigidbody>().AddForce(movement * speed);
    }

    //function to find the closest pick up target
    //GameObject GetClosestPickUp (List<GameObject> PickUps)
    GameObject TargetClosestPickUp()
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        //foreach (GameObject potentialTargetObj in PickUps)
        foreach (KeyValuePair<GameObject,GameObject> potentialTargetObj in PickUpHandler.openPickUpDictionary[allegiance])
        {
            if(potentialTargetObj.Value == null)
            //if (!potentialTargetObj.gameObject.GetComponent<PickUp>().IsCollected())
            {
                //GameObject potentialTarget = potentialTargetObj.Key;
                Vector3 directionToTarget = potentialTargetObj.Key.transform.position - currentPosition;
                //directionToTarget.Normalize();
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    //bestTarget = potentialTarget;
                    bestTarget = potentialTargetObj.Key;
                }
            }
        }
        if(bestTarget != null)
        {
            PickUpHandler.TargetPickUp(bestTarget, this.gameObject, allegiance);
        }
        aimTarget = bestTarget;
        return bestTarget;
    }

    //Collision effects
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") && !atCapacity && (other.gameObject.Equals(aimTarget) || PickUpHandler.IsAvailablePickUp(other.gameObject, allegiance)))
        {
            if (!other.gameObject.Equals(aimTarget))
            {
                PickUpHandler.UntargetPickUp(aimTarget, allegiance);
            }
            PickUpCargo(other);
        }
        else if (other.gameObject.Equals(HomeZone) && atCapacity)
        {
            DeliverCargo();
        }

        //TODO: stolen pickups push notifications from PickUpHandler
        /*
        if (other.gameObject.CompareTag("Pick Up") && !atCapacity)
        {
            if (!other.gameObject.Equals(aimTarget))
            {
                if (gameScope.IsAvailablePickUp(other.transform))
                {
                    gameScope.RemoveFromAvailPickUps(other.transform);
                    gameScope.AddToAvailPickUps(aimTarget);
                }
                else
                {
                    //gameScope.AddToStolenPickUps(other.transform);
                    gameScope.AddToAvailPickUps(aimTarget);
                    //Something
                }

            }
            PickUpCargo(other);
        }
        else if (other.gameObject.CompareTag(COLLECTION_ZONE) && atCapacity)
        {
            DeliverCargo();
        }
        */
    }

    private void DeliverCargo()
    {
        //gameScope.RemoveFromAvailPickUps(cargo.transform); //Hopefully not needed
        PickUpHandler.DeliverPickUp(cargo.gameObject, allegiance);
        Destroy(cargo.gameObject);
        atCapacity = false;
        GameResources.AddResource(1, allegiance);
        // TODO Add to global resource count

    }

    private void PickUpCargo(Collider other)
    {
        PickUpHandler.CarryPickUp(other.gameObject, this.gameObject, allegiance);
        aimTarget = null;
        other.gameObject.GetComponent<PickUp>().PickedUp(this.transform);
        cargo = other.gameObject;
        atCapacity = true;
    }

    public void SetHomeZone(GameObject zone)
    {
        HomeZone = zone;
    }

    public void SetAllegiance(GameResources.Allegiance newAllegiance)
    {
        allegiance = newAllegiance;
    }

}
