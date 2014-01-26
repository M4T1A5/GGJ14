using UnityEngine;
using System.Collections;

public class Thermometer : MonoBehaviour
{
    public float startHeat;
    public float heatDissipationSpeed = 1;
    public GameObject kiuas;
    public GameObject youWin;

    private OutOfWood wood;
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
        wood = kiuas.GetComponent<OutOfWood>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        turnToHeat(heat);
        Heat -= Time.deltaTime * heatDissipationSpeed;

        if (heat <= 20)
        {
            wood.HitSomeTrees(this);
        }
        else if (heat >= 140)
        {
            var go = (GameObject)Instantiate(youWin);
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
