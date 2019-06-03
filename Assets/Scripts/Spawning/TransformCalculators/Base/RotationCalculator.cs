using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Spawning.TransformCalculators.Base {
    public abstract class RotationCalculator : MonoBehaviour {

        public abstract Quaternion CalculateRotation(Transform obj);

    }
}