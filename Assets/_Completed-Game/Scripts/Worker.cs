using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {

    public float speed;
    bool atCapacity;
    GameObject cargo;

    // Use this for initialization
    void Start () {
        atCapacity = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!atCapacity)
        {
            //find direction to closest pick up
            GameObject[] AllPickUps = GameObject.FindGameObjectsWithTag("Pick Up");  //returns GameObject[]
            Transform Target = GetClosestPickUp(AllPickUps).transform;
            //move towards target on x, y plane
            Vector3 movement = (Target.position - transform.position);
            movement = new Vector3(movement.x, 0.0f, movement.z);
            movement.Normalize();
            GetComponent<Rigidbody>().AddForce(movement * speed);
        }
        else
        {
            Transform Target = GameObject.Find("CollectionZone").transform;
            Vector3 movement = (Target.position - transform.position);
            movement = new Vector3(movement.x, 0.0f, movement.z);
            movement.Normalize();
            GetComponent<Rigidbody>().AddForce(movement * speed);
        }

    }

    //function to find the closest pick up target
    GameObject GetClosestPickUp (GameObject[] PickUps)
    {
        GameObject bestTarget = GameObject.Find("CollectionZone");
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTargetObj in PickUps)
        {
            if (!potentialTargetObj.gameObject.GetComponent<PickUp>().IsCollected())
            {
                Transform potentialTarget = potentialTargetObj.transform;
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
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
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pick Up") && !atCapacity)
        {
            // move the pick up to the worker
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<PickUp>().PickedUp(this.gameObject);
            cargo = other.gameObject;
            atCapacity = true;
        }

        // if tag 'CollectionZone'
        if (other.gameObject.CompareTag("CollectionZone") && atCapacity)
        {
            Destroy(cargo);
            atCapacity = false;
        }
    }

}
