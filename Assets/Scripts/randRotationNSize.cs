using UnityEngine;
using System.Collections;

public class randRotationNSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Rotate(Random.rotation.eulerAngles);
        //transform.localScale = new Vector3(
        //    Random.Range(0.8f, 1.2f),
        //    Random.Range(0.8f, 1.2f),
        //    Random.Range(0.8f, 1.2f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
