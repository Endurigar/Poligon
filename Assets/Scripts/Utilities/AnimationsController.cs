using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        AddListeners();
    }

    private void AddListeners()
    {
        Containers.ActionContainer.OnShoot += () => animator.SetTrigger("OnShoot");
        Containers.ActionContainer.OnReload += () => animator.SetTrigger("OnReload");
    }
    public void OnReloadEnd()
    {
        ActionContainer.OnReloadEnd();
    }
}
