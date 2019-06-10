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

        [SerializeField]
        private GameManager gameManager;

        private void Awake() {
            trackableBehavior?.RegisterTrackableEventHandler(this);
        }

        /// <summary>
        /// Handles a change in tracking state (called by an instance of trackablebehavior).
        /// </summary>
        /// <param name="previousStatus"></param>
        /// <param name="newStatus"></param>
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {

            transform.localScale = Vector3.one;
            if (TrackedFirstTime(previousStatus, newStatus)) {
                hasAlreadyTracked = true;
                level.SetActive(true);
            }

            if (LostTracking(previousStatus, newStatus)) {
                transform.localScale = Vector3.zero;
            }

            if (newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
                gameManager.SetMarkerScanned(true);
            } else {
                gameManager.SetMarkerScanned(false);
            }
        }

        /// <summary>
        /// Checks if the TrackableBehaviour lost the marker. 
        /// </summary>
        /// <param name="previousStatus"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        private bool LostTracking(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
            return newStatus == TrackableBehaviour.Status.NO_POSE && previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED ||
                newStatus == TrackableBehaviour.Status.NO_POSE && previousStatus == TrackableBehaviour.Status.TRACKED;
        }

        /// <summary>
        /// checks if this this is the first time the TrackableBehaviour tracked the marker. 
        /// </summary>
        /// <param name="previousStatus"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        private bool TrackedFirstTime(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
            return newStatus == TrackableBehaviour.Status.TRACKED && !hasAlreadyTracked;
        }

    }
}