using UnityEngine;

public class UIMove : MonoBehaviour
{
    Vector2 targetPos = Vector2.zero;
    float moveTime = 1f;

    float currentTime = 0f;
    bool isMoving = false;
    RectTransform trans;

    public void Move(Vector2 pos, float time)
    {
        // gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
        targetPos = pos;
        moveTime = time;
        isMoving = true;
        currentTime = 0f;
    }

    void Start()
    {
        trans = gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (!isMoving) return;
        currentTime += Time.deltaTime;
        trans.anchoredPosition = Vector2.Lerp(trans.anchoredPosition, targetPos, currentTime/moveTime);
        if (trans.anchoredPosition == targetPos) isMoving = false;
    }
}