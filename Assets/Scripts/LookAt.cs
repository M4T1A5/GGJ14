using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
    public GameObject LookTarget;

    //private Quaternion startRotation;
	// Use this for initialization
	void Start () 
    {
        //startRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.LookAt(LookTarget.transform);

        //Quaternion otherRotation = transform.localRotation;

        //transform.localRotation = startRotation;
        //transform.localRotation = otherRotation * startRotation;
        
	}
}
