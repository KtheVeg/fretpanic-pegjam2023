using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float lane = 0f;
    Vector3 startPostion = new Vector3( -3.4f, 0.213f, -4.63f);
    float offset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && lane < 5) { 
            lane++;
            rb.transform.position = startPostion + new Vector3( -lane * offset, 0, 0);
        }
        if (Input.GetKeyDown("left") && lane > 0) {
            lane--; 
            rb.transform.position = startPostion + new Vector3( -lane * offset, 0, 0);
        }
    }
}
