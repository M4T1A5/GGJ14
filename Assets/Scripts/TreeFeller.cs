using UnityEngine;
using System.Collections;

public class TreeFeller : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float coolDownTime = 2.0f;
    public GUIText healthText;

    private float coolDownTimer = 0;
    private Animation animation;

	// Use this for initialization
	void Start()
    {
        animation = GetComponent<Animation>();
	}

    void Update()
    {
        coolDownTimer -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (coolDownTimer <= 0)
        {
            animation.Play();
            health -= damage;
            coolDownTimer = coolDownTime;
		 }       
    }

    void OnGUI()
    {
        healthText.text = "Tree health: " + health;
    }
}
