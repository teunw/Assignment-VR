using UnityEngine.Assertions.Comparers;

namespace VRTK.Examples
{
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        public float TimeBetweenShots;
        public AudioSource GunSound;
        public float BulletSpeed = 10000f;

        private GameObject bullet;
        private float bulletLife = 5f;
        private float shotTimer = 0f;

        private bool Fire = false;

        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);
            Fire = true;
            FireBullet();
        }

        public override void OnInteractableObjectUnused(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUnused(e);
            Fire = false;
        }

        protected void Update()
        {
            base.Update();
            shotTimer -= Time.deltaTime;
        }

        protected void Start()
        {
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
        }

        private void FireBullet()
        {
            if (!Fire && shotTimer <= 0) return;
            shotTimer = TimeBetweenShots;

            GameObject bulletClone =
                Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * BulletSpeed);
            Destroy(bulletClone, bulletLife);

            if (GunSound != null)
            {
                GunSound.Play();
            }
        }
    }
}