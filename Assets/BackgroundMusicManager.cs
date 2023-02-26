using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource loop;
    public AudioSource fail;
    public void PlayStart()
    {
        intro.Play();
    }
    public void Fail()
    {
        loop.Stop();
        fail.Play();
    }

    void Update()
    {
        if (intro.time >= intro.clip.length)
        {
            loop.Play();
        }
    }
}
