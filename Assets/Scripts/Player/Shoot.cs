using System.Collections;
using Containers;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;
using Random = UnityEngine.Random;

namespace Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletStart;
        [SerializeField] private ShootingPattern shootingPattern;
        private readonly Vector3 cameraCenter = new Vector3(0.5f, 0.5f, 0);
        private int bulletsCounter = 0;
        private int paternIndex = 0;
        private Vector3[] bullets;
        private bool onReload = false;
        private bool held = false;
        private Coroutine timer;

        private void Start()
        {
            GenerateMagazine();
            StartCoroutine(BulletsRoutine());
            AddListener();
        }

        private void AddListener()
        {
            ActionContainer.OnReloadEnd += () => onReload = false;
        }

        public void OnShoot(InputValue value)
        {
            if (onReload)
            {
                return;
            }
            held = !held;
        }

        public void OnRestart(InputValue value)
        {
            onReload = true;
            held = false;
            ActionContainer.OnReload();
            bulletsCounter = 0;
            paternIndex = 0;
        }
        
        private void GenerateMagazine()
        {
            bullets = new Vector3[shootingPattern.magazine];
            for (int i = 1; i < bullets.Length; i++)
            {
                switch (Random.Range(1, 4))
                {
                    case 1:
                        bullets[i] = new Vector3(0, bullets[i - 1].y + shootingPattern.recoilSpread,
                            bullets[i - 1].z + shootingPattern.recoilSpread);
                        break;
                    case 2:
                        bullets[i] = new Vector3(0, bullets[i - 1].y + shootingPattern.recoilSpread,
                            bullets[i - 1].z - shootingPattern.recoilSpread);
                        break;
                    case 3:
                        bullets[i] = new Vector3(0, bullets[i - 1].y - shootingPattern.recoilSpread,
                            -bullets[i - 1].z - shootingPattern.recoilSpread);
                        break;
                    case 4:
                        bullets[i] = new Vector3(0, bullets[i - 1].y - shootingPattern.recoilSpread,
                            -bullets[i - 1].z + shootingPattern.recoilSpread);
                        break;
                }
            }
        }

        IEnumerator BulletSpawn()
        {
            Vector3 forwardDirection = Camera.main.ViewportPointToRay(cameraCenter).direction;
            Rigidbody newBullet = Instantiate(bullet, bulletStart.transform.position, gameObject.transform.rotation)
                .GetComponent<Rigidbody>();
            var newRotation = newBullet.transform.eulerAngles;
            newRotation = new Vector3(newRotation.x, newRotation.y + 90, newRotation.z);
            newBullet.transform.eulerAngles = newRotation;
            if (paternIndex == 0)
            {
                newBullet.AddForce((forwardDirection) * shootingPattern.speed);
            }

            if (bulletsCounter < shootingPattern.magazine)
            {
                newBullet.AddForce((forwardDirection + bullets[paternIndex]) * shootingPattern.speed);
            }
            else
            {
                Destroy(newBullet.gameObject);
                if (timer != null)
                {
                    StopCoroutine(timer);
                }

                yield break;
            }
            Containers.ActionContainer.OnShoot();
            bulletsCounter++;
            paternIndex++;
            yield return null;
        }

        IEnumerator BulletsRoutine()
        {
            while (true)
            {
                if (held && !onReload)
                {
                    if (timer != null)
                    {
                        StopCoroutine(timer);
                    }

                    timer = StartCoroutine(RecoilController());
                    yield return StartCoroutine(BulletSpawn());
                    yield return new WaitForSeconds(shootingPattern.timeBetweenBullets);
                }
                yield return new WaitForFixedUpdate();
            }
        }

        IEnumerator RecoilController()
        {
            yield return new WaitForSeconds(shootingPattern.recoilTime);
            paternIndex = 0;
            timer = null;
        }
    }
}
