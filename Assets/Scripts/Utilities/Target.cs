using Containers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utilities
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private ParticleSystem impact;
        public float timeForSelfdestroy = 3;

        private void Start()
        {
            GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            Destroy(gameObject, timeForSelfdestroy);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                ActionContainer.OnHittingTheTarget();
                Instantiate(impact, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}