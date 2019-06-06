using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Spawning.TransformCalculators.Base;

namespace PeppaSquad.Spawning.TransformCalculators.Position {
    /// <summary>
    /// Calculates a position within a cuboid
    /// </summary>
    public class CubePositionCalculator : PositionCalculator {
        [SerializeField]
        public Vector3 offset = Vector3.zero;
        [SerializeField]
        public Vector3 size = Vector3.one;

        [SerializeField]
        private bool calculateLocalPosition = true;

        [SerializeField]
        private bool gizmoDrawArea;

        /// <summary>
        /// Calculates a position within a cuboid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>the calculated position</returns>
        public override Vector3 CalculatePosition(Transform obj) {
            Vector3 randomVector = GetRandomVectorInRange();
            randomVector += offset;
            if (!calculateLocalPosition)
                randomVector += transform.position;

            return randomVector;
        }

        /// <summary>
        /// Calculates the actual position
        /// </summary>
        /// <returns>a position within a cuboid</returns>
        private Vector3 GetRandomVectorInRange() {
            var x = Random.Range(-size.x / 2, size.x / 2);
            var y = Random.Range(-size.y / 2, size.y / 2);
            var z = Random.Range(-size.z / 2, size.z / 2);
            return new Vector3(x, y, z);
        }

        private void OnDrawGizmos() {
            if (!gizmoDrawArea)
                return;

            Gizmos.DrawWireCube(transform.position + offset, size);
        }
    }
}