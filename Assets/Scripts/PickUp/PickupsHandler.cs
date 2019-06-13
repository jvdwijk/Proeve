using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;

namespace PeppaSquad.Pickups {
    /// <summary>
    /// Handels when WWs are availible for pickup. 
    /// </summary>
    public class PickupsHandler : MonoBehaviour {

        [SerializeField]
        private NumberRange pickupWaveCooldownRange;
        [SerializeField]
        private NumberRange waveTimeRange;

        [SerializeField]
        private List<PickupController> pickups;
        private List<PickupController> disabledPickups = new List<PickupController>();

        private Coroutine spawnRoutine;

        /// <summary>
        /// Time range before next WW starts pickup-waving
        /// </summary>
        public NumberRange PickupWaveCooldown => pickupWaveCooldownRange;
        /// <summary>
        /// Time the WWs wave
        /// </summary>
        public NumberRange WaveTime => waveTimeRange;

        /// <summary>
        /// Starts making WWs availible for pickup
        /// </summary>
        /// <returns></returns>
        public void StartSpawningPickups() {
            spawnRoutine = StartCoroutine(SpawnPickups());
        }

        public void StopSpawningPickups() {
            if (spawnRoutine != null)
                StopCoroutine(spawnRoutine);

            foreach (var pickup in pickups) {
                pickup.StopPickupWave();
                disabledPickups.Remove(pickup);
                pickups.Add(pickup);
            }
        }

        private void OnDisable() {
            StopSpawningPickups();
        }

        /// <summary>
        /// Starts making WWs availible for pickup
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnPickups() {
            while (true) {
                StartWaving();

                float delay = PickupWaveCooldown.GetRandom();
                yield return new WaitForSeconds(delay);
            }
        }

        /// <summary>
        /// Makes a random WWs availible for pickup
        /// </summary>
        private void StartWaving() {
            int pickupIndex = Random.Range(0, pickups.Count);
            var pickup = pickups[pickupIndex];

            pickup.StartPickupWave();

            pickups.Remove(pickup);
            disabledPickups.Add(pickup);

            float waveTime = waveTimeRange.GetRandom();
            pickup.StopPickupWaveAfter(waveTime, () => {
                pickups.Add(pickup);
                disabledPickups.Remove(pickup);
            });

        }

        /// <summary>
        /// Gets all pickups in the scene (only called by context menu)
        /// </summary>
        [ContextMenu("Get All Pickups")]
        private void GetAllPickups() {
            pickups = new List<PickupController>(FindObjectsOfType<PickupController>());
        }

        /// <summary>
        /// Sets the pickup spawn delay 
        /// </summary>
        /// <param name="receiveDelay">Delay as one number</param>
        public void SetDelayValue(float receiveDelay) {
            SetDelayValue(new NumberRange(receiveDelay, receiveDelay));
        }

        /// <summary>
        /// /// Sets the pickup spawn delay 
        /// </summary>
        /// <param name="receiveDelay">Delay as number range</param>
        public void SetDelayValue(NumberRange receiveDelay) {
            if (receiveDelay == null)
                return;

            pickupWaveCooldownRange = receiveDelay;
        }

    }
}