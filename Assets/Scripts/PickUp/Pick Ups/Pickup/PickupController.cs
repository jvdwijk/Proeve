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

        [SerializeField]
        private Animator animator;

        private const string WaveAnimationKey = "IsWaving";

        public bool CanPickUp { get; private set; }

        private void Awake() {
            boostEffect = effectSpawner.SpawnRandomBoost();
        }

        public void StartPickupWave() {
            if (CanPickUp)
                return;

            input.OnClicked += OnPickedUp;
            CanPickUp = true;

            animator.SetBool(WaveAnimationKey, true);
        }

        public void StopPickupWave() {
            if (!CanPickUp)
                return;

            input.OnClicked -= OnPickedUp;
            CanPickUp = false;

            animator.SetBool(WaveAnimationKey, false);
        }

        private void OnPickedUp() {
            input.OnClicked -= OnPickedUp;
            boostEffect.Boost();

            StopPickupWave();
        }
    }
}