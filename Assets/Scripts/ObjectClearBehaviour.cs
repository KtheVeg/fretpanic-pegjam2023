using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClearBehaviour : MonoBehaviour
{
    float currentState = 0f;
    public void ClearObjects(Vector3 pos)
    {
        currentState = 0f;
        transform.localScale = Vector3.zero;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState > 1f)
        {
            transform.localScale = Vector3.zero;
            transform.position = Vector3.zero;
            return;
        }
        currentState += Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(15,15,15), currentState);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
