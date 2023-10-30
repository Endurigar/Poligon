using Containers;
using UnityEngine;

namespace Utilities
{
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
            ActionContainer.OnShoot += () => animator.SetTrigger("OnShoot");
            ActionContainer.OnReload += () => animator.SetTrigger("OnReload");
        }
        public void OnReloadEnd()
        {
            ActionContainer.OnReloadEnd();
        }
    }
}
