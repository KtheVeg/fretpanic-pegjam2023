using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPMonitor : MonoBehaviour
{
    int lastHealth = 0;
    float currentState = 0f;
    void Update()
    {
        if (currentState < 1f)
        {
            currentState += Time.deltaTime;
            gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3((float)Player.HP/3f,1,1), currentState);
        }
        if (Player.HP == lastHealth) return;
        lastHealth = Player.HP;
        currentState = 0f;
    }
}
