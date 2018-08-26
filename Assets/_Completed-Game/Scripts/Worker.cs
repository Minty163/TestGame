using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {

    public float speed;
    bool atCapacity;
    GameObject cargo;
    PickUpHandler pickUpHandler;
    GameResources gameResources;
    GameObject HomeZone;
    //const string COLLECTION_ZONE = "CollectionZone";
    GameObject aimTarget;
    GameResources.Allegiance allegiance;


    // Use this for initialization
    void Start () {
        atCapacity = false;
        //HomeZone = GameObject.Find(COLLECTION_ZONE).transform;
        aimTarget = HomeZone;
        //pickUpHandler = GameObject.Find("PickUpHandler").GetComponent<PickUpHandler>();
        //gameResources = GameObject.Find("GameResources").GetComponent<GameResources>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!atCapacity)
        {
            if (aimTarget.Equals(HomeZone))
            {
                //Debug.Log("CollectionZoneTarget");
                //find direction to closest pick up
                List<GameObject> AllPickUps = PickUpHandler.availPickUps;
                GameObject Target = GetClosestPickUp(AllPickUps);
                PickUpHandler.RemoveFromAvailPickUps(Target);
                aimTarget = Target;
            }
            //Debug.Log("Push Target");
            //move towards target on x, y plane
            Vector3 movement = (aimTarget.transform.position - transform.position);
            movement = new Vector3(movement.x, 0.0f, movement.z);
            movement.Normalize();
            GetComponent<Rigidbody>().AddForce(movement * speed);
        }
        else
        {
            GameObject Target = HomeZone;
            Vector3 movement = (Target.transform.position - transform.position);
            movement = new Vector3(movement.x, 0.0f, movement.z);
            movement.Normalize();
            GetComponent<Rigidbody>().AddForce(movement * speed);
        }

        //Normalize Rotate
        GetComponent<Rigidbody>().AddRelativeTorque(-1 * this.transform.rotation.x, -1 * this.transform.rotation.y, -1 * this.transform.rotation.z);
        //GetComponent<Rigidbody>().AddForce(0.0f, speed * Mathf.Max(Mathf.Min(0.5f - this.transform.position.y, 10), -10), 0.0f);
        GetComponent<Rigidbody>().AddForce(0.0f, speed * (0.5f - this.transform.position.y), 0.0f);
        //GetComponent<Rigidbody>().AddForce()

    }

    //function to find the closest pick up target
    GameObject GetClosestPickUp (List<GameObject> PickUps)
    {
        GameObject bestTarget = HomeZone;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTargetObj in PickUps)
        {
            if (!potentialTargetObj.gameObject.GetComponent<PickUp>().IsCollected())
            {
                GameObject potentialTarget = potentialTargetObj;
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                //directionToTarget.Normalize();
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    //bestTarget = potentialTarget;
                    bestTarget = potentialTargetObj;
                }
            }
        }
        //bestTarget.Normalize();
        return bestTarget;
    }

    //Collision effects
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") && !atCapacity && (other.gameObject.Equals(aimTarget) || PickUpHandler.IsAvailablePickUp(other.gameObject)))
        {
            if (!other.gameObject.Equals(aimTarget))
            {
                PickUpHandler.RemoveFromAvailPickUps(other.gameObject);
                PickUpHandler.AddToAvailPickUps(aimTarget);
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
        Destroy(cargo.gameObject);
        atCapacity = false;
        gameResources.AddResource(1);
        // TODO Add to global resource count

    }

    private void PickUpCargo(Collider other)
    {
        aimTarget = HomeZone;
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

    public void SetGameResources(GameResources newGameResources)
    {
        gameResources = newGameResources;
    }

    /*
    private bool IsIdealPickUp(Collider other)
    {
        return other.gameObject.CompareTag("Pick Up") && other.gameObject.Equals(aimTarget) && !atCapacity;
    }

    private bool IsOtherWorkersPickUp(Collider other)
    {
        return other.gameObject.CompareTag("Pick Up") && !other.gameObject.Equals(aimTarget) && !atCapacity;
    }

    private bool IsOtherPickUpTarget(Collider other)
    {
        return other.gameObject.CompareTag("Pick Up") && !other.gameObject.Equals(aimTarget) && !atCapacity;
    }
    */
}
