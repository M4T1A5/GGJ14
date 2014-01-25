using UnityEngine;
using System.Collections;

public class OutOfWood : MonoBehaviour
{
    public static GameObject SaunaContainer;
	// Use this for initialization
	void Start()
    {
        SaunaContainer = GameObject.Find("SaunaContainer");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevelAdditive("puunhakkuu");
            SaunaContainer.SetActive(false);
        }
	}
}
