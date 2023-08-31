using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnTarget : MonoBehaviour
{
    [SerializeField] private Collider plane;
    [SerializeField] private GameObject target;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private void Start()
    {
        minBounds = plane.bounds.min;
        maxBounds = plane.bounds.max;
        Instantiate(target, minBounds, Quaternion.identity);
        Instantiate(target, maxBounds, Quaternion.identity);
    }
}
