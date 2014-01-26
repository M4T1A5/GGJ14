using UnityEngine;
using System.Collections;

public class TreeFeller : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float coolDownTime = 2.0f;
    public GUIText healthText;

    private float coolDownTimer = 0;
    private Animation treeAnimation;
    private GameObject saunaContainer;

	// Use this for initialization
	void Start()
    {
        treeAnimation = GetComponent<Animation>();
        saunaContainer = TreeTransition.SaunaContainer;
	}

    void Update()
    {
        coolDownTimer -= Time.deltaTime;

        if (treeAnimation.clip.name == "TreeFell" && !treeAnimation.isPlaying)
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
                treeAnimation.clip = treeAnimation.GetClip("TreeFell");

            treeAnimation.Play();
            coolDownTimer = coolDownTime;
        }
    }

    void OnGUI()
    {
        healthText.text = "Tree health: " + health;
    }
}
