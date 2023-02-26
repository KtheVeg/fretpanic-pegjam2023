using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudioManager : MonoBehaviour
{
    public AudioSource[] sounds = new AudioSource[6];
    public void Play()
    {
        int soundHit = Random.Range(0,5);
        sounds[soundHit].Play();
    }
}
