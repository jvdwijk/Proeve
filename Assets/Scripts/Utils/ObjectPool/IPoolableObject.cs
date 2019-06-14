using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils.ObjectPool {
    public interface IPoolableObject<T> where T : IPoolableObject<T> {

        ObjectPool<T> ObjectPool { get; set; }
        void PoolObject();

    }
}