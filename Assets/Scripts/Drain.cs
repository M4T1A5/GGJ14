using UnityEngine;
using System.Collections;

public class Drain : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Destroy(other.gameObject);
        }
    }
}
