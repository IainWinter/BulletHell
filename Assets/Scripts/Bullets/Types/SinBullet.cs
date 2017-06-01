using UnityEngine;
using System.Collections;
using System;

namespace Bullets.Types {
    public class SinBullet : Bullet {
        [SerializeField] float periodSpeedMod;
        [SerializeField] float yMod;

        protected override void BulletStart() {

        }

        protected override float BulletSpeedUpdate() {
            float sinSpeed = Mathf.Sin(Mathf.Repeat(Time.time * periodSpeedMod, 2 * Mathf.PI)) + yMod;
            return Time.deltaTime * sinSpeed * bulletSpeedMod;
        }
    }
}