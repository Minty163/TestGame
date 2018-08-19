using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResources : MonoBehaviour {

    public Text countText;
    public Text winText;
    private int resourceCount;

    // Use this for initialization
    void Start () {
        // Set the count to zero 
        resourceCount = 0;

        // Run the SetCountText function to update the UI (see below)
        SetResourceText();

        // Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetResourceText()
    {
        // Update the text field of our 'countText' variable
        countText.text = "Resources: " + resourceCount.ToString();

        // Check if our 'resources' is equal to or exceeded 100
        if (resourceCount >= 100)
        {
            // Set the text value of our 'winText'
            winText.text = "You Win!";
        }
    }

    public void AddResource(int resources)
    {
        resourceCount = resourceCount + resources;
        SetResourceText();
    }

    public int GetResourceCount()
    {
        return resourceCount;
    }
}
