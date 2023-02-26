using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public bool shielded;
    public GameObject clearObj;
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Damage":
                // --DO DAMAGE OR SOMETHING -- //
                
                
                clearObj.GetComponent<ObjectClearBehaviour>().ClearObjects(transform.position, shielded ? new Color(255,0,0) : new Color(0,0,255));
            break;
            case "Powerup":
                switch (other.gameObject.GetComponent<Powerup>().powerupType)
                {
                    case PowType.HP:
                        // Health
                    break;
                    case PowType.Shield:
                        // Shield
                    break;
                    case PowType.Clear:
                        // Clear
                        clearObj.GetComponent<ObjectClearBehaviour>().ClearObjects(transform.position, new Color(0,255,0));
                    break;
                }
            break;
        }
    }
}
