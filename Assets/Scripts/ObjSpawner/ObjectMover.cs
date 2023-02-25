using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed = 1f;
    public float maxDistance = 5f;
    private float distanceTraveled = 0f;
    public bool move = false;

    void Update()
    {
        if (!move) return;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        distanceTraveled += speed * Time.deltaTime;
        if (distanceTraveled >= maxDistance)
        {
            GameObject.Destroy(gameObject, 0);
        }
    }
}