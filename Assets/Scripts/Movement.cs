using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static int lane = 0;
    public static Vector3 startPostion = new Vector3( 0.5875f, 0.3f, -4.63f);
    public static float offset = 0.235f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && lane < 5) { 
            lane++;
            gameObject.transform.position = startPostion + new Vector3( -lane * offset, 0, 0);
        }
        if (Input.GetKeyDown("left") && lane > 0) {
            lane--; 
            gameObject.transform.position = startPostion + new Vector3( -lane * offset, 0, 0);
        }
    }
}
