using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups.Effects;
using PeppaSquad.Utils.ObjectPool;

namespace PeppaSquad.Pickups {
    /// <summary>
    /// Controlles the pickups (WWs)
    /// </summary>
    public class PickupController : MonoBehaviour, IPoolableObject<PickupController> {

        [SerializeField]
        private BoostEffect boostEffect;

        [SerializeField]
        private PickupInput input;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private ParticleSystem edibleParticleSystem;

        private Coroutine pickupWaveTimer;

        private const string WaveAnimationKey = "IsWaving";

        [SerializeField]
        private BoostType boostStatType;

        public BoostType BoostStatType { get{ return boostStatType;}}
        
        public bool CanPickUp { get; private set; }
        public ObjectPool<PickupController> ObjectPool { get; set; }

        /// <summary>
        /// Called when pickup becomes availible/unavailible for pickup
        /// </summary>
        public event Action<PickupController, bool> OnCanPickUpChanged;
        /// <summary>
        /// Called when WW has been picked up
        /// </summary>
        public event Action<PickupController> PickedUp;

        /// <summary>
        /// Makes the WW availible for pickup.
        /// </summary>
        public void StartPickupWave() {
            if (CanPickUp)
                return;

            input.OnClicked += OnPickedUp;
            CanPickUp = true;
            edibleParticleSystem?.gameObject.SetActive(true);

            animator.SetBool(WaveAnimationKey, true);
            OnCanPickUpChanged?.Invoke(this, true);
        }

        /// <summary>
        /// Makes the WW unavailible for pickup.
        /// </summary>
        public void StopPickupWave() {
            if (!CanPickUp)
                return;

            input.OnClicked -= OnPickedUp;
            CanPickUp = false;
            edibleParticleSystem?.gameObject.SetActive(false);

            animator.SetBool(WaveAnimationKey, false);
            OnCanPickUpChanged?.Invoke(this, false);
        }

        /// <summary>
        /// Makes the WW unavailible for pickup after a given amount of seconds.
        /// </summary>
        /// <param name="seconds">Delay before stop</param>
        /// <param name="stoppedWaving">Callback, called when ww stopped waving</param>
        public void StopPickupWaveAfter(float seconds, Action stoppedWaving = null) {
            if (!CanPickUp)
                return;

            pickupWaveTimer = StartCoroutine(StopPickupWaveTimer(seconds, stoppedWaving));
        }

        /// <summary>
        /// Called when WW has been pickud up by player
        /// </summary>
        private void OnPickedUp() {
            input.OnClicked -= OnPickedUp;
            boostEffect.Boost();
            if (pickupWaveTimer != null)
                StopCoroutine(pickupWaveTimer);
            StopPickupWave();
            PickedUp?.Invoke(this);
        }

        /// <summary>
        /// Makes the WW unavailible for pickup after a given amount of seconds.
        /// </summary>
        /// <param name="time">Delay before stop</param>
        /// <param name="stoppedWaving">Callback, called when ww stopped waving</param>
        /// <returns></returns>
        private IEnumerator StopPickupWaveTimer(float time, Action stoppedWaving) {
            yield return new WaitForSeconds(time);
            StopPickupWave();
            stoppedWaving?.Invoke();
        }

        public void PoolObject() {
            ObjectPool.PoolObject(this);
        }
    }
}