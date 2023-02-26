using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSmooth : MonoBehaviour
{
    public int lastLane = 0;
    public float moveTime = 0.3f;
    public float movePhaseTime = 0f;

    private Vector3 goal = Movement.startPostion;

    // Update is called once per frame
    void Update()
    {
        if (Movement.lane != lastLane)
        {
            movePhaseTime = 0f;
            lastLane = Movement.lane;
            goal = Movement.startPostion + new Vector3( -Movement.lane * Movement.offset, 0, 0);
        }
        movePhaseTime += Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, goal, movePhaseTime/moveTime);
    }
}
