using System;
using UnityEngine;

namespace Spawners.Behaviours {
    [RequireComponent(typeof(Spawner))]
    public class ShotgunSpawner : SpawnerBehaviour {
        [SerializeField] int count;
        [SerializeField] float startingRotation;
        [SerializeField] float range;
        private float[] zRotations;

        protected override void StartBehaviour() {
            float minRot = startingRotation - range / 2;
            float maxRot = minRot + range;
            zRotations = new float[count];
            for (int i = 0; i < count; i++) {
                zRotations[i] = minRot + range / (count - 1)  * i;
            }
        }

        public override void UpdateBehaviour() {
            foreach (float zRotation in zRotations) {
                AddToBatch(zRotation);
            }
        }

        public override void Spawned(GameObject spawned) {
        
        }
    }
}