using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public Transform Worker;
    public Transform CollectionZone;
    public GameResources gameResources;
    public int workerCost;
    private Vector3 spawnDirection;
    public GameResources.Allegiance allegiance;

    // Use this for initialization
    void Start()
    {
        //Instantiate(Worker, new Vector3(1, 1, 0), Quaternion.identity);
        //gameResources = GameObject.Find("GameResources").GetComponent<GameResources>();
        spawnDirection = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    public void Spawn()
    {
        //this.transform.position.x;
        //Instantiate(Worker, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1), Quaternion.identity);
        Transform createdWorker = (Transform)Instantiate(Worker, this.transform.position + (this.transform.rotation * spawnDirection), Quaternion.identity);
        Worker workerObject = createdWorker.GetComponent<Worker>();
        workerObject.SetHomeZone(CollectionZone);
        workerObject.SetAllegiance(allegiance);
        workerObject.SetGameResources(gameResources);
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
