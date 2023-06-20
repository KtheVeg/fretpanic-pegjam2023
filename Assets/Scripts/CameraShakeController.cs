using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    public float duration = 1f;
    public float intensity = 0.5f;
    public float frequency = 50f;
    public bool taperIntensity = true;
    [SerializeField]
    float currentTime;
    [SerializeField]
    float currentPulse;
    [SerializeField]
    Vector3 target = Vector3.zero;
    [SerializeField]
    Vector3 lastTarget = Vector3.zero;
    [SerializeField]
    bool shakeActive = false;
    [SerializeField]
    bool returnToOrigin = false;
    [SerializeField]
    bool doShake = false;
    
    public void Shake(float _duration = 1f, float _intensity = 0.5f, float _frequency = 500f, bool _taperIntensity = false)
    {
        duration = _duration;
        intensity = _intensity;
        frequency = _frequency;
        transform.localPosition = Vector3.zero;
        if (!shakeActive) StartCoroutine(ShakeAction(_duration, _intensity, _frequency, _taperIntensity));
    }
    
    IEnumerator ShakeAction(float _duration, float _intensity, float _frequency, bool _taperIntensity = false)
    {
        Debug.Log($"ShakeAction({_duration}, {_intensity}, {_frequency})");
        // Setup Basic Values
        shakeActive = true;
        returnToOrigin = false;
        currentTime = 0f;
        currentPulse = 0f;

        // Set initial target
        target = new Vector3(Random.Range(0, _intensity), Random.Range(0, _intensity), Random.Range(0, _intensity));

        // Shake Loop
        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;
            currentPulse += Time.deltaTime;

            // If it's past the frequency, reset the pulse and set a new target
            if (currentPulse >= 1/_frequency && !returnToOrigin)
            {
                currentPulse = 0f;
                lastTarget = target;
                target = new Vector3(Random.Range(0, _intensity), Random.Range(0, _intensity), Random.Range(0, _intensity));
            }

            // For the last pulse, lerp to zero
            if (currentTime >= (_duration - currentPulse/(1/_frequency)) && !returnToOrigin) {lastTarget = target;target = Vector3.zero;returnToOrigin = true;}

            // Lerp to the target
            transform.localPosition = Vector3.Lerp(lastTarget, target, currentPulse/(1/_frequency));

            // Taper the intensity
            if (_taperIntensity) _intensity = Mathf.Lerp(_intensity, 0f, currentTime/_duration);
            
            yield return new WaitForEndOfFrame();
        }
        shakeActive = false;
    }
    void Update()
    {
        // Trigger the shake from the inspector
        if (doShake) {StartCoroutine(ShakeAction(duration, intensity, frequency)); doShake = false;}
    }

    // void Update()
    // {
    //     if (!shakeActive) return;
    //     currentTime += Time.deltaTime;
    //     currentPulse += Time.deltaTime;
    //     if (currentTime >= duration && !returnToOrigin)
    //     {
    //         target = Vector3.zero;
    //         returnToOrigin = true;
    //         duration = 0.5f;
    //         currentTime = 0f;
    //     }
    //     if (currentPulse >= 1/frequency && !returnToOrigin)
    //     {
    //         currentPulse = 0f;
    //         target = new Vector3(Random.Range(0,intensity), Random.Range(0, intensity), Random.Range(0, intensity));
    //     }
    //     if (currentTime >= duration && returnToOrigin)
    //     {
    //         currentTime = 0f;
    //         shakeActive = false;
    //         returnToOrigin = false;
    //     }
    //     transform.localPosition = Vector3.Lerp(transform.localPosition, target, currentPulse/(1/frequency));
    // }

}
