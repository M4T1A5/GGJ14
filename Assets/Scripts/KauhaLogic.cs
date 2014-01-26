using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttributeLimit
{
    public float speed;
    public float min;
    public float max;
}

[System.Serializable]
public class KauhaAttributes
{
    public AttributeLimit pitch;
    public AttributeLimit horizontal;
    public AttributeLimit roll;
    public AttributeLimit forward;
    public AttributeLimit vertical;
}

public class KauhaLogic : MonoBehaviour
{
    public KauhaAttributes attributes;

    public GameObject kauha;

    private float wantedPitch;
    private float wantedRoll;
    private float currentRoll;
    private float wantedVertical;
    private float wantedHorizontal;
    private float wantedForward;



	// Use this for initialization
	void Start ()
    {
        attributes.pitch.min += 0;
        attributes.pitch.max += 0;

        attributes.horizontal.min += transform.localPosition.x;
        attributes.horizontal.max += transform.localPosition.x;

        attributes.roll.min += 0;
        attributes.roll.max += 0;

        attributes.forward.min += transform.localPosition.z;
        attributes.forward.max += transform.localPosition.z;

        attributes.vertical.min += transform.localPosition.y;
        attributes.vertical.max += transform.localPosition.y;


        Screen.lockCursor = true;
        wantedPitch = 0;
        wantedRoll = 0;
        currentRoll = 0;
        wantedVertical = transform.localPosition.y;
        wantedHorizontal = transform.localPosition.x;
        wantedForward = transform.localPosition.z;
        
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

        // LEFT - RIGHT
        wantedHorizontal += Input.GetAxis("Mouse X") * attributes.horizontal.speed;
        wantedHorizontal *= 0.5f;
        movement.x = wantedHorizontal;
        {
            float clamped = Mathf.Clamp(transform.localPosition.x, attributes.horizontal.min, attributes.horizontal.max);
            if (Mathf.Abs(transform.localPosition.x - clamped) >= 0.001f)
                movement.x += (-transform.localPosition.x + clamped) * attributes.horizontal.speed*2;
        }

        //wantedHorizontal = Mathf.Clamp(wantedHorizontal, attributes.horizontal.min, attributes.horizontal.max);
        //movement.x = -transform.localPosition.x + wantedHorizontal;
        //wantedHorizontal -= movement.x * 0.5f;
        //wantedHorizontal *= 0.5f;
        //movement.x = horizontalMovement;

        // FORWARD - BACKWARD
        wantedForward += Input.GetAxis("Mouse Y") * attributes.forward.speed;
        wantedForward *= 0.5f;
        movement.z = wantedForward;
        {
            float clamped = Mathf.Clamp(transform.localPosition.z, attributes.forward.min, attributes.forward.max);
            if (Mathf.Abs(transform.localPosition.z - clamped) >= 0.001f)
                movement.z += (-transform.localPosition.z + clamped) * attributes.forward.speed;
        }

        // UP - DOWN
        if (Input.GetButton("Fire1"))
            wantedVertical += attributes.vertical.speed;
        if (Input.GetButton("Fire2"))
            wantedVertical -= attributes.vertical.speed;
        wantedVertical *= 0.9f;
        movement.y = wantedVertical;
        {
            float clamped = Mathf.Clamp(transform.localPosition.y, attributes.vertical.min, attributes.vertical.max);
            if (Mathf.Abs(transform.localPosition.y - clamped) >= 0.001f)
                movement.y += (-transform.localPosition.y + clamped) * attributes.vertical.speed * 10;
        }

         // ROLL - DON'T ROLL
        if (Input.GetButton("Fire3"))
            wantedRoll -= attributes.roll.speed;
        else
            wantedRoll += attributes.roll.speed;
        wantedRoll = Mathf.Clamp(wantedRoll, attributes.roll.min, attributes.roll.max);
        currentRoll = 0.9f * currentRoll + 0.1f * wantedRoll;
        kauha.transform.localRotation = new Quaternion(currentRoll, 0, 0, 1);

        // TURN UP - TURN DOWN
        wantedPitch += Input.GetAxis("Mouse ScrollWheel") * attributes.pitch.speed;
        wantedPitch *= 0.9f;
        torque.x += wantedPitch;


        rigidbody.AddForce(movement, ForceMode.VelocityChange);
        rigidbody.AddTorque(torque, ForceMode.VelocityChange);
    }
}
