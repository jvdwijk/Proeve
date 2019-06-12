using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Utils;

namespace PeppaSquad.Pickups {
    public class PickupSpawner : MonoBehaviour {

        [SerializeField]
        private NumberRange numberRandomizer;

        [SerializeField]
        private PickupsHandler PickupsHandler;

        [SerializeField]
        private List<Transform> spawnPositions;
        private List<Transform> freeSpawnPositions = new List<Transform>();

        [SerializeField]
        private PickupObjectPool[] objectPools;

        [SerializeField]
        private int[] colorAmount;

        private List<PickupController> pickups = new List<PickupController>();

        public void SpawnPickups() {
            freeSpawnPositions?.Clear();
            freeSpawnPositions.AddRange(spawnPositions);

            for (int size = 0; size < colorAmount.Length; size++) {
                for (int pickUp = 0; pickUp < colorAmount[size]; pickUp++) {
                    numberRandomizer.SetRange(0, freeSpawnPositions.Count - 1);
                    SetPickUp(objectPools[size]);
                }
            }
        }

        private void SetPickUp(PickupObjectPool pool) {
            bool wwSpawned = false;
            while (!wwSpawned) {
                var newSpot = GetRandomEmptySpot();
                if (newSpot == null) continue;

                PickupController pickup = pool.GetObject();
                pickup.transform.SetParent(newSpot);
                pickup.transform.localPosition = Vector3.zero;
                pickup.transform.localRotation = Quaternion.identity;
                
                pickups.Add(pickup);
                PickupsHandler.Pickups.Add(pickup);
                
                wwSpawned = true;
            }
        }

        private Transform GetRandomEmptySpot() {
            int newNumber = (int) numberRandomizer.GetRandom();
            Transform returnTransform = freeSpawnPositions[newNumber];
            freeSpawnPositions.RemoveAt(newNumber);
            return returnTransform;
        }

        public void DestroyPickUps() {
            for (int i = 0; i < pickups.Count; i++) {
                PickupController pickup = pickups[i];
                pickup.PoolObject();
            }
            pickups.Clear();
            PickupsHandler.Pickups.Clear();
        }
    }
}