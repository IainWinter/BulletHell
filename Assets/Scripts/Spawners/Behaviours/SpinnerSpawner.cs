using Bullets;
using System;
using UnityEngine;

namespace Spawners.Behaviours {
    public class SpinnerSpawner : RotationBehaviour {
        protected override void StartRotationBehaviour() {

        }

        public override void UpdateBehaviour() {
            zRotation = Mathf.Repeat(zRotation + ((reversed ? -speed - zRotationMod : speed + zRotationMod)), 360);
            AddToBatch(zRotation);
        }
    }
}