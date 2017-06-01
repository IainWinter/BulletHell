using UnityEngine;
using System.Collections;

namespace Bullets {
    public abstract class Bullet : Damageable {
        [SerializeField] float _bulletSpeedMod;
        protected float bulletSpeedMod;
        protected Vector3 bulletStart;
        public float currentSpeed;

        public void Start() {
            bulletSpeedMod = _bulletSpeedMod;
            bulletStart = transform.localPosition;
            BulletStart();
            currentSpeed = BulletSpeedUpdate();
        }

        void Update() {
            currentSpeed = BulletSpeedUpdate();
            transform.Translate(currentSpeed, 0, 0);

            if (Vector3.Distance(bulletStart, transform.position) > 25f) {
                Kill();
            }
        }

        protected abstract void BulletStart();
        protected abstract float BulletSpeedUpdate();
    }
}
