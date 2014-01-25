using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform objectToSpawn;
    public Transform containerObject;
    public float spawnInterval;

    private float spawnTimer;

	// Use this for initialization
	void Start()
    {
        spawnTimer = spawnInterval;

        //InvokeRepeating("Spawn", 0, spawnInterval);
	}

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Spawn();
            spawnTimer = spawnInterval;
        }
    }
	
	// Update is called once per frame
	void Spawn()
    {
        var go = (Transform)Instantiate(objectToSpawn, transform.position, transform.rotation);
        go.transform.parent = containerObject;
	}
}
