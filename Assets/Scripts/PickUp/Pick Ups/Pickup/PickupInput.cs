using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PeppaSquad.Pickups {
    /// <summary>
    /// Handles the pickup input.
    /// </summary>
    public class PickupInput : MonoBehaviour {

        /// <summary>
        /// Called when pickup is clicked
        /// </summary>
        public event Action OnClicked;

        /// <summary>
        /// Unity callback, called when object is clicked.
        /// </summary>
        private void OnMouseDown() {
            OnClicked?.Invoke();
        }

    }
}