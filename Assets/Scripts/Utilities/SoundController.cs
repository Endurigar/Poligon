using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip shootAudio;
    [SerializeField] private AudioClip reloadAudio;
    [SerializeField] private AudioClip footstepsAudio;
    [SerializeField] private PlayerInput playerInput;

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        playerInput.actions["Move"].started += MoveSoundHandler;
        playerInput.actions["Move"].canceled += MoveSoundHandler;
        ActionContainer.OnShoot += () => AudioSource.PlayClipAtPoint(shootAudio, gameObject.transform.position);
        ActionContainer.OnReload += () => AudioSource.PlayClipAtPoint(reloadAudio, gameObject.transform.position);
    }

    private void MoveSoundHandler (InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(FootstepsSound());   
        }
        else if (context.canceled)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator FootstepsSound()
    {
        AudioSource.PlayClipAtPoint(footstepsAudio, gameObject.transform.position);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FootstepsSound());
    }
}
