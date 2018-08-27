using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public bool collected { get; set; }
    Transform transport;
    public float Speed;
    //public float Speed { get; set; }

    private void Start()
    {
        collected = false;
        transport = null;
    }

    // Before rendering each frame..
    void FixedUpdate () 
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        if (collected)
        {
            Vector3 target = new Vector3(transport.transform.position.x, transport.transform.position.y + 1, transport.transform.position.z);
            Vector3 movement = (target - transform.position);
            //movement = new Vector3(movement.x, 0.0f, movement.z);
            //movement.Normalize();
            GetComponent<Rigidbody>().AddForce(movement * Speed);
        }
	}

    public void PickedUp (Transform collector)
    {
        //
        collected = true;
        transport = collector;
    }

    public bool IsCollected()
    {
        return collected;
    }
}	