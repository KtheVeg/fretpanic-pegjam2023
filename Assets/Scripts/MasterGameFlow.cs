using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MasterGameFlow : MonoBehaviour
{
    public SpawnManager spawnmgr;
    public BackgroundMusicManager bgmmgr;
    public VideoPlayer visualizer;
    void Start()
    {
        bgmmgr.PlayStart();
        visualizer.Play();
    }
}
