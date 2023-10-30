using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    private float lastPositionY;

    private void OnJump(InputValue value)
    {
        lastPositionY = gameObject.GetComponent<Collider>().bounds.min.y;
        StartCoroutine(Raycast());
    }

    IEnumerator Raycast()
    {
        float minY = gameObject.GetComponent<Collider>().bounds.min.y;
        RaycastHit raycastHit;
        bool yDiff = lastPositionY > minY;
        Ray ray = new Ray(transform.position, transform.up * -1);
        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity) && yDiff)
        {
            Debug.DrawRay(transform.position, transform.up * -10, Color.magenta, duration: 0.1f);
            Debug.Log(raycastHit.transform.gameObject.name);
            Debug.Log(Mathf.Abs(raycastHit.point.y - minY));
            if (Mathf.Abs(raycastHit.point.y - minY) <= 0.03f)
            {
                Debug.Log("ALO");
                AudioSource.PlayClipAtPoint(jumpSound, gameObject.transform.position);
                yield break;
            }
        }
        yield return new WaitForEndOfFrame();
        if(!yDiff)
        lastPositionY = minY;
        StartCoroutine(Raycast());
    }
}
