using UnityEngine;
using System.Collections;

public class KauhaTesti : MonoBehaviour
{
    public Vector2 speed;

    private float wantedAngle;

	// Use this for initialization
	void Start ()
    {
        Screen.lockCursor = true;
        wantedAngle = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Mouse ScrollWheel") * 50 * Time.deltaTime, transform.position.z);
	}

    void FixedUpdate()
    {

        rigidbody.angularVelocity = new Vector3();
        rigidbody.velocity = new Vector3();

        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 torque = new Vector3(0.0f, 0.0f, 0.0f);
        //rigidbody.AddForce(0, Input.GetAxis("Fire1"), 0, ForceMode.Impulse); //Input.GetAxis("Mouse ScrollWheel");


        if (Input.GetButton("Fire1"))
        {
            movement.y += speed.y;
        }

        if (Input.GetButton("Fire2"))
        {
            movement.y -= speed.y;
        }

        if (Input.GetButton("Fire3"))
        {
            //torque.y += Input.GetAxis("Mouse Y") * speed.x;
            //torque.x += Input.GetAxis("Mouse X") * speed.x;
        }

        wantedAngle *= 0.9f;
        wantedAngle += Input.GetAxis("Mouse ScrollWheel") * speed.y;
        torque.x += wantedAngle;

        

        movement.x += Input.GetAxis("Mouse X") * speed.x;
        movement.z += Input.GetAxis("Mouse Y") * speed.x;

        //if (torque.sqrMagnitude < 1)
        //{         
        //}
        rigidbody.AddForce(movement, ForceMode.VelocityChange);   

        rigidbody.AddTorque(torque, ForceMode.VelocityChange);
    }
}
