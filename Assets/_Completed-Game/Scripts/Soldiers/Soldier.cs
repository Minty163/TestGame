using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

    public float speed;
    public float fireSpeed = 8;
    GameObject aimTarget;
    public GameResources.Allegiance allegiance { get; set; }
    public Vector3 fireFrom;
    private bool readyToFire;
    private Vector3 directionOfTarget;
    private Vector3 fireFromAdjusted;


    // Use this for initialization
    void Start()
    {
        fireFrom = new Vector3(0, 0.26f, 0.4f);
        readyToFire = true;
        aimTarget = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move towards target on x, y plane
        /*
        Vector3 movement = (aimTarget.transform.position - transform.position);
        movement = new Vector3(movement.x, 0.0f, movement.z);
        movement.Normalize();
        */
        Vector3 movement = new Vector3(0, 0, 1);
        //GetComponent<Rigidbody>().AddForce(movement * speed);
        directionOfTarget = (aimTarget.transform.position - this.transform.position).normalized;
        Vector3 up = new Vector3(0, 1, 0);

        //Normalize Rotate
        //GetComponent<Rigidbody>().AddRelativeTorque(-this.transform.rotation.x, -this.transform.rotation.y, -this.transform.rotation.z);
        //GetComponent<Rigidbody>().AddRelativeTorque(- this.transform.rotation.eulerAngles.normalized);
        //GetComponent<Rigidbody>().AddRelativeTorque(directionOfTarget - new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z));
        GetComponent<Rigidbody>().AddRelativeTorque(Quaternion.LookRotation(directionOfTarget, up).x - this.transform.rotation.x, Quaternion.LookRotation(directionOfTarget, up).y - this.transform.rotation.y, Quaternion.LookRotation(directionOfTarget, up).z - this.transform.rotation.z);
        //GetComponent<Rigidbody>().AddForce(0.0f, speed * Mathf.Max(Mathf.Min(0.5f - this.transform.position.y, 10), -10), 0.0f);
        GetComponent<Rigidbody>().AddForce(0.0f, speed * (0.5f - this.transform.position.y), 0.0f);
        //GetComponent<Rigidbody>().AddForce()

        if (readyToFire)
        {
            FireCannon(aimTarget.transform);
        }
    }

    GameObject FireCannon(Transform targetTransform)
    {
        float gravity = 9.81f;
        fireFromAdjusted = AdjustVectorToSoldierRotation(fireFrom);
        float range = (targetTransform.position - (this.transform.position + fireFromAdjusted)).magnitude;
        //float a = Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2));
        //float b = (Mathf.Pow(fireSpeed, 2) - Mathf.Sqrt(Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2)))) / 2;
        //float xComp = Mathf.Sqrt((Mathf.Pow(fireSpeed, 2) + Mathf.Sqrt(Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2))))/2);
        float xComp = Mathf.Sqrt((Mathf.Pow(fireSpeed, 2) - Mathf.Sqrt(Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2)))) / 2);
        float yComp = Mathf.Sqrt(Mathf.Pow(fireSpeed, 2) - Mathf.Pow(xComp, 2));

        readyToFire = false;
        //GameObject bullet = GameObject.Instantiate(Resources.Load<GameObject>("Bullets/Bullet"), this.transform.position + ((new Vector3((this.transform.rotation * fireFrom).x, 0, (this.transform.rotation * fireFrom).z)).normalized), this.transform.rotation);
        GameObject bullet = GameObject.Instantiate(Resources.Load<GameObject>("Bullets/Bullet"), this.transform.position + fireFromAdjusted, this.transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(0, 300, 300);
        //bullet.GetComponent<Rigidbody>().AddForce(0, yComp, xComp);
        //bullet.GetComponent<Rigidbody>().velocity = new Vector3 (0, yComp, xComp);
        bullet.GetComponent<Rigidbody>().velocity = AdjustVectorToSoldierRotation(new Vector3(0, yComp, xComp));
        StartCoroutine(WaitToFire(3.0f));
        return bullet;
    }

    private Vector3 AdjustVectorToSoldierRotation(Vector3 inVector)
    {
        return new Vector3((this.transform.rotation * inVector).x, inVector.y, (this.transform.rotation * inVector).z);
    }

    private IEnumerator WaitToFire(float waitTime)
    {
        while (!readyToFire)
        {
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);
            readyToFire = true;
        }
    }

    //function to find the closest pick up target
    /*
    GameObject GetClosestPickUp(List<GameObject> PickUps)
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
    */

}
