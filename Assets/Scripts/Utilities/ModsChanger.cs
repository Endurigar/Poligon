using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;

public class ModsChanger : MonoBehaviour
{
    private RandomSpawnTarget randomSpawnTarget;
    private SpawnMovingTargets spawnMovingTargets;
    private void Start()
    {
        randomSpawnTarget = gameObject.GetComponent<RandomSpawnTarget>();
        spawnMovingTargets = gameObject.GetComponent<SpawnMovingTargets>();
        AddListener();
    }

    private void AddListener()
    {
        ActionContainer.OnModeChanged += ModsChangeHandler;
    }

    private void ModsChangeHandler(ModsEnum modID)
    {
        switch (modID)
        {
            case ModsEnum.StaticTargetMode:
                randomSpawnTarget.enabled = true;
                spawnMovingTargets.enabled = false;
                break;
            case ModsEnum.MovingTargetMode:
                randomSpawnTarget.enabled = false;
                spawnMovingTargets.enabled = true;
                break;
        }
    }
}
