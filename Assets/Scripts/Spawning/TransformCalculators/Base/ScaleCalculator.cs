using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Spawning.TransformCalculators.Base {
    public abstract class ScaleCalculator : MonoBehaviour {
        public abstract Vector3 CalculateScale(Transform obj);
    }
}