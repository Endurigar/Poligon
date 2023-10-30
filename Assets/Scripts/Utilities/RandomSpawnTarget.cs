using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawnTarget : MonoBehaviour
{
    [SerializeField] protected Collider plane;
    [SerializeField] protected GameObject target;
    protected GameObject lastTarget;
    protected Vector3 minBounds;
    protected Vector3 maxBounds;
    protected float easySpeed = 2;


    private void Start()
    {
        AddListener();
    }
    
    private void AddListener()
    {
        ActionContainer.OnDifficultyChange += DifficultyChange;
    }

    private void OnEnable()
    {
        minBounds = plane.bounds.min;
        maxBounds = plane.bounds.max;
        StartCoroutine(TargetSpawner(easySpeed));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    protected virtual void InstantiateTargetRandomPosition(float speed)
    {
        lastTarget = Instantiate(target, new Vector3(Random.Range(minBounds.x,maxBounds.x),Random.Range(minBounds.y,maxBounds.y),Random.Range(minBounds.z,maxBounds.z)), Quaternion.identity);
        lastTarget.GetComponent<Target>().timeForSelfdestroy = speed;
    }

    private void DifficultyChange(float newSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(TargetSpawner(newSpeed));
    }

    IEnumerator TargetSpawner(float speed)
    {
        InstantiateTargetRandomPosition(speed); 
        yield return new WaitForSeconds(speed);
        StartCoroutine(TargetSpawner(speed));
    }
}
