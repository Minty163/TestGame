using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public Transform Worker;

    // Use this for initialization
    void Start()
    {
        //Instantiate(Worker, new Vector3(1, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    public void Spawn()
    {
        //this.transform.position.x;
        Instantiate(Worker, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1), Quaternion.identity);
    }
}
