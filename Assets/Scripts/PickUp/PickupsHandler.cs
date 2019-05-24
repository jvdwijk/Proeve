using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;

namespace PeppaSquad.Pickups {
    public class PickupsHandler : MonoBehaviour {

        [SerializeField]
        private NumberRange pickupWaveCooldownRange;
        [SerializeField]
        private NumberRange waveTimeRange;

        [SerializeField]
        private List<PickupController> pickups;
        private List<PickupController> disabledPickups = new List<PickupController>();

        public NumberRange PickupWaveCooldown => pickupWaveCooldownRange;
        public NumberRange WaveTime => waveTimeRange;

        private void Awake() {
            StartCoroutine(SpawnPickups());
        }

        private IEnumerator SpawnPickups() {
            while (true) {
                StartWaving();

                float delay = PickupWaveCooldown.GetRandom();
                yield return new WaitForSeconds(delay);
            }
        }

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

        [ContextMenu("Get All Pickups")]
        private void GetAllPickups() {
            pickups = new List<PickupController>(FindObjectsOfType<PickupController>());
        }

        public void SetDelayValue(float receiveDelay){
            SetDelayValue(new NumberRange(receiveDelay, receiveDelay));
        }

        public void SetDelayValue(NumberRange receiveDelay){
            if(receiveDelay == null)
                return;

            pickupWaveCooldownRange = receiveDelay;   
        }

    }
}