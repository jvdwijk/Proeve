using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Spawning.TransformCalculators.Base;

namespace PeppaSquad.Spawning.TransformCalculators.Rotation {
    public class LookAtCameraRotationCalculator : RotationCalculator {

        private new Camera camera;

        [SerializeField]
        public Vector3 offset;

        public override Quaternion CalculateRotation(Transform obj) {
            Camera usedCamera = camera != null ? camera : Camera.main;
            Vector3 relativePos = usedCamera.transform.position - obj.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            rotation = Quaternion.Euler(rotation.eulerAngles + offset);
            return rotation;
        }
    }
}