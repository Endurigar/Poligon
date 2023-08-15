using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletImpact : MonoBehaviour
{
    [SerializeField] private AudioClip bulletImpactSound;
    
    void Start()
    {
        AudioSource.PlayClipAtPoint(bulletImpactSound, gameObject.transform.position);
        DecalProjector decalProjector = GetComponent<DecalProjector>();
        DOVirtual.Float(decalProjector.fadeFactor, 0, 5,
            v => decalProjector.fadeFactor = v).OnComplete(() => {Destroy(gameObject);});
    }
}
