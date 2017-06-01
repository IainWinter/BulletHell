using IwTools;
using UnityEngine;

namespace Spawners.Behaviours {
    [RequireComponent(typeof(Spawner))]
    public abstract class SpawnerBehaviour : MonoBehaviour {
        [SerializeField] Object _prefab;
        protected Object prefab;

        [SerializeField] int millisDelay;
        private ElapsedTime elapsedTime;
        private Spawner spawner;

        void Start() {
            elapsedTime = new ElapsedTime();
            spawner = GetComponent<Spawner>();

            prefab = _prefab;
            StartBehaviour();
        }

        public void UpdateSpawner() {
            if(elapsedTime.MillisSinceUpdate() > millisDelay) {
                elapsedTime.Update();
                UpdateBehaviour();
            }
        }
        protected abstract void StartBehaviour();
        public abstract void UpdateBehaviour();
        public abstract void Spawned(GameObject spawned);

        protected void AddToBatch(float zRotation) {
            spawner.AddToBatch(this, prefab, zRotation);
        }
    }
}