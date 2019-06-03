using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Spawning.TransformCalculators.Base {
    /// <summary>
    /// Calculats scales
    /// </summary>
    public abstract class ScaleCalculator : MonoBehaviour {

        /// <summary>
        /// Calculates the scale for a gameobject
        /// </summary>
        /// <param name="obj">the object for which it is calculated</param>
        /// <returns>The calculated scale</returns>
        public abstract Vector3 CalculateScale(Transform obj);
    }
}