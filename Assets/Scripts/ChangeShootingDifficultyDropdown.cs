using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class ChangeShootingDifficultyDropdown : MonoBehaviour
{
    public BalloonSpawnManager BalloonSpawnManager;

    // Use this for initialization
    void Start()
    {
        var dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(dif =>
        {
            BalloonSpawnManager.ChangeDifficultly((BalloonDifficulty) Enum.Parse(typeof(BalloonDifficulty), dif.ToString()));
        });
    }
}