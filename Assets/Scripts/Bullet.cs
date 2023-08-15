using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletImpact;
    private void OnCollisionEnter (Collision other)
    {
        var newBulletImpack = Instantiate(bulletImpact, gameObject.transform.position, gameObject.transform.rotation);
        var newRotation = newBulletImpack.transform.eulerAngles;
        newRotation = new Vector3(newRotation.x, newRotation.y -  90, newRotation.z);
        newBulletImpack.transform.eulerAngles = newRotation;
        Destroy(gameObject);
    }
}
