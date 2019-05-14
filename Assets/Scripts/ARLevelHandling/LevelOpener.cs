using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Vuforia.UnityCompiled;

namespace PeppaSquad.GameFlow {
    public class LevelOpener : MonoBehaviour, ITrackableEventHandler {

        private bool hasAlreadyTracked = false;

        [SerializeField]
        private TrackableBehaviour trackableBehavior;

        [SerializeField]
        private GameObject level;

        private void Awake() {
            trackableBehavior?.RegisterTrackableEventHandler(this);
        }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {

            transform.localScale = Vector3.one;
            if (TrackedFirstTime(previousStatus, newStatus)) {
                hasAlreadyTracked = true;
                level.SetActive(true);
            }

            if (LostTracking(previousStatus, newStatus)) {
                transform.localScale = Vector3.zero;
            }
        }

        private bool LostTracking(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
            return newStatus == TrackableBehaviour.Status.NO_POSE && previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED ||
                newStatus == TrackableBehaviour.Status.NO_POSE && previousStatus == TrackableBehaviour.Status.TRACKED;
        }

        private bool TrackedFirstTime(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
            return newStatus == TrackableBehaviour.Status.TRACKED && !hasAlreadyTracked;
        }

    }
}