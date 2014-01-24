using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform gameObject;
    public Transform containerObject;
    public float spawnInterval;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", 0, spawnInterval);
	}
	
	// Update is called once per frame
	void Spawn()
    {
        var go = (Transform)Instantiate(gameObject, transform.position, transform.rotation);
        go.transform.parent = containerObject;
	}
}
