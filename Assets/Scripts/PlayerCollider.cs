using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public bool shielded;
    public GameObject shieldTex;
    public GameObject clearObj;
    public GameObject Cam;
    public HitAudioManager HAM;
    public BackgroundMusicManager bgmmgr;
    public MasterGameFlow MstGmeFlw;
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Damage":
                // --DO DAMAGE OR SOMETHING -- //
                HAM.Play();
                clearObj.GetComponent<ObjectClearBehaviour>().ClearObjects(transform.position, !shielded ? new Color(255,0,0) : new Color(0,0,255));
                if (!shielded) {
                    Player.HP--;
                    Cam.GetComponent<CameraShakeController>().Shake(0.5f, 0.1f, 500f, true);
                    if (Player.HP <= 0) {
                        bgmmgr.Fail();
                        MstGmeFlw.Fail();
                    }
                } else {shielded = false;}
                shieldTex.SetActive(false);
            break;
            case "Powerup":
                switch (other.gameObject.GetComponent<Powerup>().powerupType)
                {
                    case PowType.HP:
                        if (Player.HP < 3) Player.HP++; 
                    break;
                    case PowType.Shield:
                        shielded = true;
                        shieldTex.SetActive(true);
                    break;
                    case PowType.Clear:
                        // Clear
                        clearObj.GetComponent<ObjectClearBehaviour>().ClearObjects(transform.position, new Color(0,255,0));
                    break;
                }
            GameObject.Destroy(other.gameObject);
            break;
        }
    }
}
