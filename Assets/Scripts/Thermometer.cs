using UnityEngine;
using System.Collections;

public class Thermometer : MonoBehaviour
{
    public float startHeat;
    public float heatDissipationSpeed = 1;

    public GameObject youlose;

    private float heat;
    public float Heat
    {
        get { return heat; }
        set { heat = Mathf.Clamp(value, 20, 140); }
    }

    private Quaternion startRotation;

	// Use this for initialization
	void Start ()
    {
        startRotation = transform.rotation;
        heat = startHeat;
	}
	
	// Update is called once per frame
	void Update ()
    {
        turnToHeat(heat);
        Heat -= Time.deltaTime * heatDissipationSpeed;

        if (heat <= 20)
        {
            var go = (GameObject)Instantiate(youlose);
            Destroy(go, 5.0f);
            enabled = false;
        }

	}

    void turnToHeat(float heat)
    {
        transform.rotation = startRotation;
        transform.Rotate(new Vector3(0, 1, 0), (heat - 20) / 20 * -45, Space.Self);
    }
}
