using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class JumpTrigger : MonoBehaviour
    {
        [SerializeField] private AudioClip jumpSound;
        private float lastPositionY;
        private const float Threshold = 0.03f;

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
                if (Mathf.Abs(raycastHit.point.y - minY) <= Threshold)
                {
                    AudioSource.PlayClipAtPoint(jumpSound, gameObject.transform.position);
                    yield break;
                }
            }

            yield return new WaitForEndOfFrame();
            if (!yDiff)
                lastPositionY = minY;
            StartCoroutine(Raycast());
        }
    }
}