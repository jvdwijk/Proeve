using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils.ObjectPool {
    public abstract class ObjectPool<T> : MonoBehaviour {

        private List<T> pooledObjects = new List<T>();

        [SerializeField]
        private int startAmount;

        private void Awake() {
            for (int i = 0; i < startAmount; i++) {
                T obj = CreateNew();
                PoolObject(obj);
            }
        }

        public virtual void PoolObject(T obj) {
            pooledObjects.Add(obj);
        }

        public virtual T GetObject(bool spawnNew = true) {

            if (pooledObjects.Count > 0) {
                T obj = pooledObjects[0];
                pooledObjects.RemoveAt(0);
                return obj;
            } else if (spawnNew) {
                return CreateNew();
            }
            return DefaultValue();
        }

        protected virtual T CreateNew() {
            return default(T);
        }

        protected virtual T DefaultValue() {
            return default(T);
        }

    }
}