using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups.Effects;

namespace PeppaSquad.Pickups {
    public class PickupController : MonoBehaviour {

        [SerializeField]
        private BoostEffect boostEffect;

        [SerializeField]
        private BoostEffectSpawner effectSpawner;

        [SerializeField]
        private PickupInput input;

        public bool CanPickUp { get; private set; }

        private void Awake() {
            StartPickupCheer();
            boostEffect = effectSpawner.SpawnRandomBoost();
        }

        public void StartPickupCheer() {
            input.OnClicked += OnPickedUp;
            CanPickUp = true;

            //TODO start cheer animations
        }

        public void StopPickupCheer() {
            input.OnClicked -= OnPickedUp;
            CanPickUp = false;

            //TODO stop cheer animations
        }

        private void OnPickedUp() {
            input.OnClicked -= OnPickedUp;
            boostEffect.Boost();

            //TODO reset animations and deactivate gameobject.
        }
    }
}