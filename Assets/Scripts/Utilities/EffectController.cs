using Containers;
using UnityEngine;

namespace Utilities
{
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
}