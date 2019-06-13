using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;
using System;

namespace PeppaSquad.Pickups {
    /// <summary>
    /// Handels when WWs are availible for pickup. 
    /// </summary>
    public class PickupsHandler : MonoBehaviour {

        [SerializeField]
        private PickupSpawner pickUpSpawner;

        [SerializeField]
        private NumberRange pickupWaveCooldownRange;
        [SerializeField]
        private NumberRange waveTimeRange;

        [SerializeField]
        private List<PickupController> pickups;

        public List<PickupController> Pickups {get{return pickups;}}

        public Dictionary<BoostType, int> BoostTypeDict {get; private set;} = new Dictionary<BoostType, int>();
        public Dictionary<BoostType, int> ReadyBoostsDict {get; private set;} = new Dictionary<BoostType, int>();

        public event Action OnDictChange;

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
            pickUpSpawner.SpawnPickups();
            CountTotalPickups();
            ResetReadyPickupsDict();
            spawnRoutine = StartCoroutine(SpawnPickups());
        }

        public void RemovePickUps(){
            pickUpSpawner.DestroyPickUps();
        }

        /// <summary>
        /// Starts making WWs availible for pickup
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnPickups() {
            while (true) {
                StartWaving();

                float delay = pickupWaveCooldownRange.GetRandom();
                yield return new WaitForSeconds(delay);
            }
        }

        /// <summary>
        /// Makes a random WWs availible for pickup
        /// </summary>
        private void StartWaving() {
            int pickupIndex = UnityEngine.Random.Range(0, pickups.Count);
            var pickup = pickups[pickupIndex];
            
            if(ReadyBoostsDict[pickup.BoostStatType] > 2 || pickup.CanPickUp) return;

            pickup.StartPickupWave();
            pickup.PickedUp += OnPickupUsed;
            ChangeDict(ReadyBoostsDict, pickup.BoostStatType);

            pickups.Remove(pickup);
        }


        private void CountTotalPickups(){
            BoostTypeDict.Clear();
            pickups.ForEach( (pickup)=>
            {
                ChangeDict(BoostTypeDict, pickup.BoostStatType);
            });
        }

        private void ResetReadyPickupsDict(){
            ReadyBoostsDict.Clear();
            foreach (BoostType type in Enum.GetValues(typeof(BoostType)))
            {
                ChangeDict(ReadyBoostsDict, type);
            }
        }

        private void ChangeDict(Dictionary<BoostType, int> dict, BoostType type, int amount = 1){
            if(dict.ContainsKey(type)) dict[type] += amount;
            else dict.Add(type, amount);
            OnDictChange?.Invoke();
        }

        private void OnPickupUsed(PickupController pickup){
            ChangeDict(ReadyBoostsDict, pickup.BoostStatType, -1);
            ChangeDict(BoostTypeDict, pickup.BoostStatType, -1);
            pickup.PoolObject();
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
        /// Sets the pickup spawn delay 
        /// </summary>
        /// <param name="receiveDelay">Delay as number range</param>
        public void SetDelayValue(NumberRange receiveDelay) {
            if (receiveDelay == null)
                return;

            pickupWaveCooldownRange = receiveDelay;
        }

    }
}