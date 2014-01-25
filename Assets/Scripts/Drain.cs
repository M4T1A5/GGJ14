using UnityEngine;
using System.Collections;

public class Drain : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
