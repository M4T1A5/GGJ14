using UnityEngine;
using System.Collections;

[System.Serializable]
public class KauhaAttributes
{
    public float pitch;
    public float yaw;
    public float roll;
    public float forward;
    public float vertical;
}

public class KauhaTesti : MonoBehaviour
{
    public KauhaAttributes attributes;

    public GameObject kauha;

    private float wantedPitch;
    private float wantedRoll;
    private float currentRoll;
    private float wantedVertical;

	// Use this for initialization
	void Start ()
    {
        Screen.lockCursor = true;
        wantedPitch = 0;
        wantedRoll = 0;
        currentRoll = 0;
        wantedVertical = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Screen.lockCursor = true;
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
            wantedVertical += attributes.vertical * 0.1f;
        }

        if (Input.GetButton("Fire2"))
        {
            wantedVertical -= attributes.vertical * 0.1f;
        }
        wantedVertical *= 0.9f;
        movement.y = wantedVertical;

        if (Input.GetButton("Fire3"))
        {
            wantedRoll -= attributes.roll * 0.01f;
        }
        else
        {
            wantedRoll += attributes.roll * 0.01f;
            //kauha.transform.localRotation = Quaternion.identity;
        }
        wantedRoll = Mathf.Clamp(wantedRoll, -2, 0);
        currentRoll = 0.9f * currentRoll + 0.1f * wantedRoll;
        kauha.transform.localRotation = new Quaternion(currentRoll, 0, 0, 1);


        wantedPitch *= 0.9f;
        wantedPitch += Input.GetAxis("Mouse ScrollWheel") * attributes.pitch;
        torque.x += wantedPitch;



        movement.x += Input.GetAxis("Mouse X") * attributes.yaw;
        movement.z += Input.GetAxis("Mouse Y") * attributes.forward;

        //if (torque.sqrMagnitude < 1)
        //{         
        //}
        rigidbody.AddForce(movement, ForceMode.VelocityChange);   

        rigidbody.AddTorque(torque, ForceMode.VelocityChange);
    }
}
