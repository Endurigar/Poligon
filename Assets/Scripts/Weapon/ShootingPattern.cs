using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "ShootingPattern", menuName = "Settings/ShootingPattern")]
    public class ShootingPattern : ScriptableObject
    {
        public int magazine;
        public float speed;
        public float recoilSpread;
        public float timeBetweenBullets;
        public float recoilTime;
    }
}