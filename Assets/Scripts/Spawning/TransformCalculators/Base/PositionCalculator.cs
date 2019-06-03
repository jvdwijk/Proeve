using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Spawning.TransformCalculators.Base {
    /// <summary>
    /// Calculates positions
    /// </summary>
    public abstract class PositionCalculator : MonoBehaviour {

        /// <summary>
        /// Calculates the position for a gameobject
        /// </summary>
        /// <param name="obj">the object for which it is calculated</param>
        /// <returns>The calculated position</returns>
        public abstract Vector3 CalculatePosition(Transform obj);

    }
}