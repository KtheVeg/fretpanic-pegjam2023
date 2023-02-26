using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClearBehaviour : MonoBehaviour
{
    float currentState = 0f;
    public Color colour;
    public void ClearObjects(Vector3 pos)
    {
        currentState = 0f;
        transform.localScale = Vector3.zero;
        transform.position = pos;
        gameObject.GetComponent<SpriteRenderer>().color = colour;
    }
    public void ClearObjects(Vector3 pos, Color col)
    {
        currentState = 0f;
        transform.localScale = Vector3.zero;
        transform.position = pos;
        gameObject.GetComponent<SpriteRenderer>().color = col;
        colour = col;
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
        transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(3,3,3), currentState);
        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(colour, new Color(0,0,0,0), currentState);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
