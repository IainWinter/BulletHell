using UnityEngine;
using System.Collections.Generic;
using Spawners.Behaviours;
using Bullets;

namespace Spawners {
    public class Spawner : MonoBehaviour {
        private List<Projectile> batch;
        private GameManager gameManager;

        void Start() {
            batch = new List<Projectile>();
            gameManager = Camera.main.GetComponent<GameManager>();
        }

        void Update() {
            if (gameManager.CanShoot()) {
                batch.Clear();

                SpawnerBehaviour[] sbs = GetComponents<SpawnerBehaviour>();
                foreach (SpawnerBehaviour sb in sbs) {
                    sb.UpdateSpawner();
                }

                foreach (Projectile p in batch) {
                    GameObject go = (GameObject)Instantiate(p.prefab, transform.position, Quaternion.Euler(0, 0, p.zRotation));
                    go.GetComponent<Bullet>().Start();
                    p.behaviour.Spawned(go);
                }
            }
        }

        public void AddToBatch(SpawnerBehaviour behaviour, Object prefab, float zRotation) {
            batch.Add(new Projectile(behaviour, prefab, zRotation));
        }
    }

    public struct Projectile {
        public SpawnerBehaviour behaviour;
        public Object prefab;
        public float zRotation;

        public Projectile(SpawnerBehaviour behaviour, Object prefab, float zRotation) {
            this.behaviour = behaviour;
            this.prefab = prefab;
            this.zRotation = zRotation;
        }
    }
}