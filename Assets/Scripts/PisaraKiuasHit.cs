using UnityEngine;
using System.Collections;

public class PisaraKiuasHit : MonoBehaviour
{
    public GUIText score;
    public ParticleSystem steamEmitter;
    public GameObject soundEmmitter;
    private int hits;

    void Start()
    {
        hits = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            hits++;

            var steam = (ParticleSystem)Instantiate(steamEmitter, other.transform.position, steamEmitter.transform.rotation);
            var tshhh = (GameObject)Instantiate(soundEmmitter, other.transform.position, soundEmmitter.transform.rotation);
            tshhh.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Destroy(steam, 10.0f);
            Destroy(tshhh, 5.0f);
        }
    }

    void OnGUI()
    {
        score.text = "Sauna Score: " + hits;
    }
}
