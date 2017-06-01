using UnityEngine;
using System.Collections;
using Spawners.Behaviours;
using System;
using Bullets;
using Bullets.Types;

namespace Spawners.Behaviours {
    public abstract class RotationBehaviour : SpawnerBehaviour {
        [SerializeField] float _speed;
        [SerializeField] bool _reversed;
        [SerializeField] float startingRotation;
        protected float speed;
        protected bool reversed;
        protected float zRotation;
        protected float zRotationMod;

        protected override void StartBehaviour() {
            speed = _speed;
            reversed = _reversed;
            zRotation = startingRotation;
            StartRotationBehaviour();
        }

        protected abstract void StartRotationBehaviour();

        public override void Spawned(GameObject spawned) {
            Bullet c = spawned.GetComponent<Bullet>();
            if (c != null && c.GetType() != typeof(LinearBullet)) {
                zRotationMod = 1 / (1 + c.currentSpeed) * speed;
            } else {
                zRotationMod = 0;
            }
        }
    }
}