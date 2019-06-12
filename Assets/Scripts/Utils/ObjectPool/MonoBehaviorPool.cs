using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils.ObjectPool {
    public abstract class MonoBehaviourPool<MB> : ObjectPool<MB>
        where MB : MonoBehaviour, IPoolableObject<MB> {

            [SerializeField]
            private MB objectPrefab;

            public override void PoolObject(MB obj) {
                obj.gameObject.SetActive(false);
                base.PoolObject(obj);
            }

            public override MB GetObject(bool spawnNew = true) {
                MB obj = base.GetObject(spawnNew);
                obj.gameObject.SetActive(true);
                return obj;
            }

            protected override MB CreateNew() {
                MB obj = Instantiate(objectPrefab);
                return obj;
            }

            protected override MB DefaultValue() {
                return null;
            }

        }
}