using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Spawning.TransformCalculators.Base {
    public abstract class RotationCalculator : MonoBehaviour {

        /// <summary>
        /// Calculates the rotation for a gameobject
        /// </summary>
        /// <param name="obj">the object for which it is calculated</param>
        /// <returns>The calculated rotation</returns>
        public abstract Quaternion CalculateRotation(Transform obj);

    }
}