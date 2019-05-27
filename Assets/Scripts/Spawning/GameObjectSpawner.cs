using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Spawning.TransformCalculators.Base;

namespace PeppaSquad.Spawning {
    public class GameObjectSpawner : MonoBehaviour {

        [Header("Transform")]
        [SerializeField]
        private PositionCalculator positionCalculator;
        [SerializeField]
        private RotationCalculator rotationCalculator;
        [SerializeField]
        private ScaleCalculator scaleCalculator;

        [Header("Object")]
        [SerializeField]
        private GameObject parent;
        [SerializeField]
        private GameObject prefab;

        public event Action<GameObject> ObjectSpawned;

        [ContextMenu("Spawn")]
        public virtual void Spawn(Func<GameObject, GameObject> objectModifier = null) {
            var instance = Instantiate(prefab);
            if (parent != null)
                instance.transform.SetParent(parent.transform);
            SetTransform(instance.transform);

            if (objectModifier != null)
                instance = objectModifier.Invoke(instance);

            ObjectSpawned?.Invoke(instance);
        }

        protected virtual void SetTransform(Transform obj) {
            if (positionCalculator != null)
                obj.localPosition = positionCalculator.CalculatePosition(obj);

            if (rotationCalculator != null)
                obj.localRotation = rotationCalculator.CalculateRotation(obj);

            if (scaleCalculator != null)
                obj.localScale = scaleCalculator.CalculateScale(obj);
        }
    }
}