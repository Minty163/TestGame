﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Soldier")
        {
            other.gameObject.GetComponent<Soldier>().TakeDamage(1);
        }
        Destroy(this.gameObject);
        /*
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
        */
    }
}
