using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class MasterGameFlow : MonoBehaviour
{
    public SpawnManager spawnmgr;
    public Spawner spawner;
    public BackgroundMusicManager bgmmgr;
    public VideoPlayer visualizer;
    public float timePassed = 0f;
    public Difficulty difficulty;
    public float timeForFirstSetToArrive = 0f;
    public bool musicStarted = false;
    public bool ready = false;
    public GameObject difficultyText;
    public GameObject startScreen;
    public GameObject failScreen;
    void Start()
    {
        failScreen.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height);
    }
    void Update()
    {
        if (!ready)
        {
            if (Input.GetKeyDown("space")) {
                ready = true;
                spawnmgr.spawnEnabled = true;
                startScreen.SetActive(false);
            }
            if (Input.GetKeyDown("up"))
            {
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        difficulty = Difficulty.Medium;
                        difficultyText.GetComponent<TextMeshProUGUI>().text = "Medium";

                    break;
                    case Difficulty.Medium:
                        difficulty = Difficulty.Hard;
                        difficultyText.GetComponent<TextMeshProUGUI>().text = "Hard";
                    break;
                    case Difficulty.Hard:
                        difficulty = Difficulty.Insane;
                        difficultyText.GetComponent<TextMeshProUGUI>().text = "Insane";
                    break;
                    case Difficulty.Insane:
                        difficulty = Difficulty.Easy;
                        difficultyText.GetComponent<TextMeshProUGUI>().text = "Easy";
                    break;
                }
            }
            return;
        }
         switch (difficulty)
        {
            case Difficulty.Easy:
                spawner.randomSpeedModifierHigh = 3.86f;
                spawner.randomSpeedModifierLow = 3.86f;
                spawnmgr.spawnTime = 0.375f;
                spawnmgr.spawnRateLow = 0f;
                spawnmgr.spawnRateHigh = 0.8f;
                timeForFirstSetToArrive = 4.75f;

            break;
            case Difficulty.Medium:
                spawner.randomSpeedModifierHigh = 3.86f;
                spawner.randomSpeedModifierLow = 3.86f;
                spawnmgr.spawnTime = 0.375f;
                spawnmgr.spawnRateLow = 0.2f;
                spawnmgr.spawnRateHigh = 1;
                timeForFirstSetToArrive = 4.75f;
            break;
            case Difficulty.Hard:
                spawner.randomSpeedModifierHigh = 7.72f;
                spawner.randomSpeedModifierLow = 7.72f;
                spawnmgr.spawnTime = 0.1875f;
                spawnmgr.spawnRateLow = 0.5f;
                spawnmgr.spawnRateHigh = 1.1f;
                timeForFirstSetToArrive = 2.5f;
            break;
            case Difficulty.Insane:
                spawner.randomSpeedModifierHigh = 15.44f;
                spawner.randomSpeedModifierLow = 15.44f;
                spawnmgr.spawnTime = 0.1875f;
                spawnmgr.spawnRateLow = 0.2f;
                spawnmgr.spawnRateHigh = 1.1f;
                timeForFirstSetToArrive = 1.1f;
            break;
        }
        timePassed += Time.deltaTime;
        if (timePassed > timeForFirstSetToArrive && !musicStarted)
        {
                bgmmgr.PlayStart();
                visualizer.Play();
                musicStarted = true;
        }
    }

    public void Fail()
    {
        failScreen.SetActive(true);
        spawnmgr.spawnEnabled = false;
        GameObject[] stuff = GameObject.FindGameObjectsWithTag("Damage");
        for (int i = 0; i < stuff.Length; i++)
        {
            GameObject.Destroy(stuff[i]);
        }
    }
}
