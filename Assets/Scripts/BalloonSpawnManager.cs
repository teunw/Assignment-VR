using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public enum BalloonDifficulty
{
    EASY = 0,
    MEDIUM = 1,
    HARD = 2
}

public class BalloonSpawnManager : MonoBehaviour
{
    public List<BalloonSpawner> BalloonSpawners = new List<BalloonSpawner>();
    private BalloonDifficulty Difficulty;

    public void ChangeDifficultly(BalloonDifficulty dif)
    {
        this.Difficulty = dif;
        switch (dif)
        {
            case BalloonDifficulty.MEDIUM:
                SetMediumDifficulty();
                break;
            case BalloonDifficulty.HARD:
                SetHardDifficulty();
                break;
            default:
                SetEasyDifficulty();
                break;
        }
    }

    public void SetEasyDifficulty()
    {
        BalloonSpawners.ForEach(bs =>
        {
            bs.scale = 4.25f;
            bs.minSpawnTime = 1f;
            bs.maxSpawnTime = 3f;
        });
    }

    public void SetMediumDifficulty()
    {
        BalloonSpawners.ForEach(bs =>
        {
            bs.scale = 2.75f;
            bs.minSpawnTime = 2f;
            bs.maxSpawnTime = 5f;
        });
    }

    public void SetHardDifficulty()
    {
        BalloonSpawners.ForEach(bs =>
        {
            bs.scale = 1.5f;
            bs.minSpawnTime = 3f;
            bs.maxSpawnTime = 6f;
        });
    }
}