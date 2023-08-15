using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private ParticleSystem bulletFire;
    private void Start()
    {
        bulletFire = GetComponent<ParticleSystem>();
        AddListener();
    }

    private void AddListener()
    {
        ActionContainer.OnShoot += () => bulletFire.Play();
    }
}
