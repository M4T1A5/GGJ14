﻿using UnityEngine;
using System.Collections;

public class PisaraKiuasHit : MonoBehaviour
{
    public GUIText score;
    public GameObject steamEmitter;
    public GameObject soundEmmitter;

    public float heatGainSpeed = 1;

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

            thermometer.Heat += heatGainSpeed;

            var steam = (GameObject)Instantiate(steamEmitter, other.transform.position, steamEmitter.transform.rotation);
            var tshhh = (GameObject)Instantiate(soundEmmitter, other.transform.position, soundEmmitter.transform.rotation);
            tshhh.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Destroy(steam, 7.0f);
            Destroy(tshhh, 5.0f);
        }
    }

    void OnGUI()
    {
        score.text = "Sauna Score: " + hits;
    }
}
