using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exiter : MonoBehaviour
{
    float timeHeld = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            timeHeld += Time.deltaTime;
            if (timeHeld > 5f)
            {
                Application.Quit();
                Debug.Log("Exit");
            }
        }
        else
        {
            timeHeld = 0f;
        }
    }
}
