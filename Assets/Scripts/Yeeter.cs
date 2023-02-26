using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeeter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage") GameObject.Destroy(other.gameObject);
    }
}
