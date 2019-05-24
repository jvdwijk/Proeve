using System;
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

        private Coroutine pickupWaveTimer;

        private const string WaveAnimationKey = "IsWaving";

        public bool CanPickUp { get; private set; }

        public event Action<PickupController, bool> OnCanPickUpChanged;
        public event Action<PickupController> PickedUp;

        private void Awake() {
            boostEffect = effectSpawner.SpawnRandomBoost();
        }

        public void StartPickupWave() {
            if (CanPickUp)
                return;

            input.OnClicked += OnPickedUp;
            CanPickUp = true;

            animator.SetBool(WaveAnimationKey, true);
            OnCanPickUpChanged?.Invoke(this, true);
        }

        public void StopPickupWave() {
            if (!CanPickUp)
                return;

            input.OnClicked -= OnPickedUp;
            CanPickUp = false;

            animator.SetBool(WaveAnimationKey, false);
            OnCanPickUpChanged?.Invoke(this, false);
        }

        public void StopPickupWaveAfter(float seconds, Action stoppedWaving = null) {
            if (!CanPickUp)
                return;

            pickupWaveTimer = StartCoroutine(StopPickupWaveTimer(seconds, stoppedWaving));
        }

        private void OnPickedUp() {
            input.OnClicked -= OnPickedUp;
            boostEffect.Boost();
            if (pickupWaveTimer != null)
                StopCoroutine(pickupWaveTimer);
            StopPickupWave();
            PickedUp?.Invoke(this);
        }

        private IEnumerator StopPickupWaveTimer(float time, Action stoppedWaving) {
            yield return new WaitForSeconds(time);
            StopPickupWave();
            stoppedWaving?.Invoke();
        }
    }
}