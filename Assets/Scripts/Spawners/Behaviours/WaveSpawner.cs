using System;
using UnityEngine;

namespace Spawners.Behaviours {
    public class WaveSpawner : SpinnerSpawner {
        [SerializeField] float range;
        private float minRot;
        private float maxRot;

        protected override void StartRotationBehaviour() {
            minRot = zRotation - range / 2;
            maxRot = minRot + range;
        }

        public override void UpdateBehaviour() {
            if (zRotation >= maxRot || zRotation <= minRot) {
                reversed = !reversed;
            }

            zRotation += reversed ? -speed - zRotationMod : speed + zRotationMod;
            AddToBatch(zRotation);
        }
    }
}