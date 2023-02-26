using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject clearObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            // --DO DAMAGE OR SOMETHING -- //
            

            clearObj.GetComponent<ObjectClearBehaviour>().ClearObjects(transform.position);
        }
    }
}
