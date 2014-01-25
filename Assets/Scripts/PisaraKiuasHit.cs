using UnityEngine;
using System.Collections;

public class PisaraKiuasHit : MonoBehaviour
{
    public GUIText score;
    public ParticleSystem steamEmitter;
    public GameObject soundEmmitter;

    private Thermometer thermometer;

    private int hits;

    void Start()
    {
        hits = 0;
        thermometer = GameObject.Find("Viisari").GetComponent<Thermometer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            hits++;

            thermometer.Heat++;

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
