using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour {

    public float speed;
    public float fireSpeed;
    public GameObject aimTarget;
    public GameResources.Allegiance allegiance { get; set; }
    public int Health;
    public int MaxHealth;
    public Vector3 fireFrom;
    private bool readyToFire;
    private Vector3 directionOfTarget;
    private Quaternion turnQuat;
    private Vector3 fireFromAdjusted;
    public SoldierAI.State AIState;
    private float maxRange;
    private float targetRange;
    public Image HealthBar;
    public float Fill;


    // Use this for initialization
    void Start()
    {
        fireFrom = new Vector3(0, 0.26f, 0.4f);
        readyToFire = true;
        //aimTarget = GameObject.Find("Player");
        MaxHealth = 3;
        Health = 3;
        AIState = SoldierAI.State.Marching;
        fireSpeed = 8;
        maxRange = (Mathf.Pow(fireSpeed, 2) / 9.81f);
        //HealthBar = this.transform.GetChild(1).GetChild(0).GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (aimTarget == null)
        {
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("SoldierSpawner"))
            {
                if (item.GetComponent<SoldierSpawner>().Allegiance != allegiance)
                {
                    aimTarget = item;
                    break;
                }
            }
        }
        targetRange = (aimTarget.transform.position - (this.transform.position + fireFromAdjusted)).magnitude;
        directionOfTarget = (aimTarget.transform.position - this.transform.position).normalized;
        turnQuat = Quaternion.LookRotation(directionOfTarget) * Quaternion.Inverse(this.transform.rotation);
        GetComponent<Rigidbody>().AddTorque(turnQuat.x * turnQuat.w, turnQuat.y * turnQuat.w, turnQuat.z * turnQuat.w);
        GetComponent<Rigidbody>().AddForce(0.0f, speed * (0.5f - this.transform.position.y), 0.0f);

        if (targetRange < maxRange)
        {
            AIState = SoldierAI.State.Firing;
        }
        else
        {
            AIState = SoldierAI.State.Marching;
        }

        switch (AIState)
        {
            case SoldierAI.State.Marching:
                Vector3 movement = (aimTarget.transform.position - transform.position);
                movement = new Vector3(movement.x, 0.0f, movement.z);
                movement.Normalize();
                GetComponent<Rigidbody>().AddForce(movement * speed);
                break;
            case SoldierAI.State.Firing:
                if (readyToFire && FacingAimDirection())
                {
                    FireCannon(aimTarget.transform);
                }
                break;
            case SoldierAI.State.Reloading:
                break;
        }
    }

    private bool FacingAimDirection()
    {
        //Vector3 FacingDirection = (this.transform.rotation * new Vector3(0, 0, 1)).normalized;
        //Vector3 AimDirection = (this.transform.rotation * new Vector3(0, 0, 1)).normalized;
        Debug.Log((directionOfTarget - (this.transform.rotation * new Vector3(0, 0, 1)).normalized).magnitude);
        return (directionOfTarget - (this.transform.rotation * new Vector3(0, 0, 1)).normalized).magnitude < 0.01f;
    }

    private GameObject FireCannon(Transform targetTransform)
    {
        //float gravity = 9.81f;
        fireFromAdjusted = AdjustVectorToSoldierRotation(fireFrom);
        //float a = Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2));
        //float b = (Mathf.Pow(fireSpeed, 2) - Mathf.Sqrt(Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2)))) / 2;
        float xComp = Mathf.Sqrt((Mathf.Pow(fireSpeed, 2) + Mathf.Sqrt(Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(targetRange, 2) * Mathf.Pow(9.81f, 2))))/2); //StraightShot
        //float xComp = Mathf.Sqrt((Mathf.Pow(fireSpeed, 2) - Mathf.Sqrt(Mathf.Pow(fireSpeed, 4) - (Mathf.Pow(range, 2) * Mathf.Pow(9.81f, 2)))) / 2); //ArcShot
        float yComp = Mathf.Sqrt(Mathf.Pow(fireSpeed, 2) - Mathf.Pow(xComp, 2));

        readyToFire = false;
        //GameObject bullet = GameObject.Instantiate(Resources.Load<GameObject>("Bullets/Bullet"), this.transform.position + ((new Vector3((this.transform.rotation * fireFrom).x, 0, (this.transform.rotation * fireFrom).z)).normalized), this.transform.rotation);
        GameObject bullet = GameObject.Instantiate(Resources.Load<GameObject>("Bullets/Bullet"), this.transform.position + fireFromAdjusted, this.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = AdjustVectorToSoldierRotation(new Vector3(0, yComp, xComp));
        StartCoroutine(WaitToFire(3.0f));
        return bullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Soldier" && other.gameObject.GetComponent<Soldier>().allegiance != allegiance)
        {
            aimTarget = other.gameObject;
        }
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
            readyToFire = true;
        }
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        Fill = ((float)Health / (float)MaxHealth);
        HealthBar.fillAmount = Fill;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
