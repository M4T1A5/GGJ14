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
    private GameObject saunaContainer;

	// Use this for initialization
	void Start()
    {
        animation = GetComponent<Animation>();
        saunaContainer = OutOfWood.SaunaContainer;
	}

    void Update()
    {
        coolDownTimer -= Time.deltaTime;

        if (animation.clip.name == "TreeFell" && !animation.isPlaying)
        {
            var go = GameObject.Find("PuunHakkausContainer");
            go.SetActive(false);
            saunaContainer.SetActive(true);
            Destroy(go);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (health <= 0)
            return;

        if (coolDownTimer <= 0)
        {
            health -= damage;
            if (health <= 0)
                animation.clip = animation.GetClip("TreeFell");

            animation.Play();
            coolDownTimer = coolDownTime;
        }
    }

    void OnGUI()
    {
        healthText.text = "Tree health: " + health;
    }
}
