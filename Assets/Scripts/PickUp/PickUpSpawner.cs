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
        private Transform[] spawnPositions;

        [SerializeField]
        private PickupObjectPool[] objectPools;

        [SerializeField]
        private int[] colorAmount;

        private List<PickupController> pickups = new List<PickupController>();

        public void SpawnPickups() {
            numberRandomizer.SetRange(0, spawnPositions.Length - 1);

            for (int size = 0; size < colorAmount.Length; size++) {
                for (int pickUp = 0; pickUp < colorAmount[size]; pickUp++) {
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
                wwSpawned = true;
            }
        }

        private Transform GetRandomEmptySpot() {
            int newNumber = (int) numberRandomizer.GetRandom();

            return spawnPositions[newNumber].childCount == 0 ? spawnPositions[newNumber] : null;
        }

        public void DestroyPickUps() {
            for (int i = 0; i < pickups.Count; i++) {
                PickupController pickup = pickups[i];
                pickup.PoolObject();
            }
            pickups.Clear();
        }
    }
}