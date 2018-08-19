﻿using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
    PickUpHandler pickUpHandler;
    GameResources gameResources;
    //const string COLLECTION_ZONE = "CollectionZone";

    // Create private references to the rigidbody component on the player
    private Rigidbody rb;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

        pickUpHandler = GameObject.Find("PickUpHandler").GetComponent<PickUpHandler>();
        gameResources = GameObject.Find("GameResources").GetComponent<GameResources>();
    }

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up") && pickUpHandler.IsAvailablePickUp(other.transform))
		{
            gameResources.AddResource(1);
            
            // Make the other game object (the pick up) inactive, to make it disappear
            //other.gameObject.SetActive (false);
            pickUpHandler.RemoveFromAvailPickUps(other.gameObject.transform);
            Destroy(other.gameObject);
		}
    }

}