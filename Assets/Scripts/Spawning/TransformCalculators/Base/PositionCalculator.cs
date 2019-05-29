using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Spawning.TransformCalculators.Base {
    public abstract class PositionCalculator : MonoBehaviour {

        public abstract Vector3 CalculatePosition(Transform obj);

    }
}