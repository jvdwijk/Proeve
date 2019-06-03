using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Spawning.TransformCalculators.Base;

namespace PeppaSquad.Spawning {

    /// <summary>
    /// Spawns gameobject
    /// </summary>
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

        /// <summary>
        /// Called when a new object is spawned
        /// </summary>
        public event Action<GameObject> ObjectSpawned;

        /// <summary>
        /// Spawns a new gameobject
        /// </summary>
        /// <param name="objectModifier">Modifies the object before ObjectSpawned is called</param>
        public virtual void Spawn(Func<GameObject, GameObject> objectModifier = null) {
            var instance = Instantiate(prefab);
            if (parent != null)
                instance.transform.SetParent(parent.transform);
            SetTransform(instance.transform);

            if (objectModifier != null)
                instance = objectModifier.Invoke(instance);

            ObjectSpawned?.Invoke(instance);
        }

        /// <summary>
        /// Sets the transform of the spawned object
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void SetTransform(Transform obj) {
            if (positionCalculator != null)
                obj.localPosition = positionCalculator.CalculatePosition(obj);

            if (rotationCalculator != null)
                obj.localRotation = rotationCalculator.CalculateRotation(obj);

            if (scaleCalculator != null)
                obj.localScale = scaleCalculator.CalculateScale(obj);
        }

        /// <summary>
        /// Sets a new postition calculator
        /// </summary>
        /// <param name="calc">the new calculator</param>
        public void SetPositionCalculator(PositionCalculator calc) {
            positionCalculator = calc;
        }
        /// <summary>
        /// Sets a new rotation calculator
        /// </summary>
        /// <param name="calc">the new calculator</param>
        public void SetRotationCalculator(RotationCalculator calc) {
            rotationCalculator = calc;
        }
        /// <summary>
        /// Sets a new scale calculator
        /// </summary>
        /// <param name="calc">the new calculator</param>
        public void SetScaleCalculator(ScaleCalculator calc) {
            scaleCalculator = calc;
        }
        /// <summary>
        /// Sets a new default parent for the spawned object
        /// </summary>
        /// <param name="parent">the new parent object</param>
        public void SetParent(GameObject parent) {
            this.parent = parent;
        }
    }
}