using UnityEngine;
using System.Collections;

public class KauhaTesti : MonoBehaviour
{
    public Vector2 speed;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Mouse ScrollWheel") * 50 * Time.deltaTime, transform.position.z);
	}

    void FixedUpdate()
    {
        //rigidbody.AddForce(0, Input.GetAxis("Fire1"), 0, ForceMode.Impulse); //Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetButton("Fire1"))
        {
            rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y + speed.y * Time.deltaTime, transform.position.z));
        }

        else if (Input.GetButton("Fire2"))
        {
            rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y - speed.y * Time.deltaTime, transform.position.z));
        }
        else
        {
            rigidbody.MovePosition(new Vector3(transform.position.x + Input.GetAxis("Mouse X") * speed.x * Time.deltaTime, 
                transform.position.y, 
                transform.position.z + Input.GetAxis("Mouse Y") * speed.x * Time.deltaTime));       
        }
    }
}
