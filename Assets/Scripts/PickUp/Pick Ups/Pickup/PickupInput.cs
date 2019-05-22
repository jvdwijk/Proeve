using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PeppaSquad.Pickups {
    public class PickupInput : MonoBehaviour {

        public event Action OnClicked;

        private void OnMouseDown() {
            OnClicked?.Invoke();
        }

    }
}