using UnityEngine;
using System.Collections;

public class PisaraKiuasHit : MonoBehaviour
{
    public GUIText score;
    public ParticleSystem steamEmitter;
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

            var go = (ParticleSystem)Instantiate(steamEmitter, other.transform.position, steamEmitter.transform.rotation);
            Destroy(other.gameObject);
            Destroy(go, 10.0f);
        }
    }

    void OnGUI()
    {
        score.text = "Sauna Score: " + hits;
    }
}
