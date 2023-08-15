using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip shootAudio;

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        Containers.ActionContainer.OnShoot += () => AudioSource.PlayClipAtPoint(shootAudio, gameObject.transform.position);

    }
}
