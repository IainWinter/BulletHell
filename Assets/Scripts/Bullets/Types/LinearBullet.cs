using UnityEngine;
using System.Collections;
using System;

namespace Bullets.Types {
    public class LinearBullet : Bullet {
        protected override void BulletStart() {

        }

        protected override float BulletSpeedUpdate() {
            return Time.deltaTime * bulletSpeedMod;
        }
    }
}