﻿using UnityEngine;
using System.Collections;

public class PisaraKiuasHit : MonoBehaviour
{
    public GUIText score;
    private int hits;

    void Start()
    {
        hits = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        hits++;
        Destroy(other.gameObject);
    }

    void OnGUI()
    {
        score.text = "Sauna Score: " + hits;
    }
}
