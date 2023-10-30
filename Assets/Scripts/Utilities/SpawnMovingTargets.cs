using DG.Tweening;
using UnityEngine;

namespace Utilities
{
    public class SpawnMovingTargets : RandomSpawnTarget
    {
        private const int DOMoveDurations = 3;

        protected override void InstantiateTargetRandomPosition(float speed)
        {
            base.InstantiateTargetRandomPosition(speed);
            TargetMovement();
        }

        private void TargetMovement()
        {
            float startTarget = 0;
            float endTarget = 0;
            switch (Random.Range(0, 2))
            {
                case 0:
                    startTarget = maxBounds.z;
                    endTarget = minBounds.z;
                    break;
                case 1:
                    startTarget = minBounds.z;
                    endTarget = maxBounds.z;
                    break;
            }

            lastTarget.transform.DOMoveZ(startTarget, DOMoveDurations).OnComplete((() =>
            {
                lastTarget.transform.DOMoveZ(endTarget, DOMoveDurations);
            }));
        }
    }
}