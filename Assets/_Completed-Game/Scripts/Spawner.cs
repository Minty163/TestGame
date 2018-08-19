using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public Transform Worker;
    GameResources gameResources;
    public int workerCost;

    // Use this for initialization
    void Start()
    {
        //Instantiate(Worker, new Vector3(1, 1, 0), Quaternion.identity);
        gameResources = GameObject.Find("GameResources").GetComponent<GameResources>();
    }

    // Update is called once per frame
    public void Spawn()
    {
        //this.transform.position.x;
        Instantiate(Worker, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1), Quaternion.identity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && gameResources.GetResourceCount() >= workerCost)
        {
            // Spawn Worker
            //other.gameObject.GetComponent<Spawner>().Spawn();
            Spawn();
            gameResources.AddResource(-workerCost);
        }
    }
}
