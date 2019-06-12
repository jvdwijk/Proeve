using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PeppaSquad.Utils;

namespace PeppaSquad.Pickups {
    public class PickupSpawner : MonoBehaviour {
        
        [SerializeField]
        private NumberRange numberRandomizer;

        [SerializeField]
        private List<Transform> spawnPositions;
        private List<Transform> freeSpawnPositions = new List<Transform>();

        [SerializeField]
        private GameObject[] wwPrefab;

        [SerializeField]
        private int[] colorAmount;

        public void SpawnPickups () {
            freeSpawnPositions?.Clear();
            freeSpawnPositions.AddRange(spawnPositions);

            for (int size = 0; size < colorAmount.Length; size++)
            {
                for (int pickUp = 0; pickUp < colorAmount[size]; pickUp++)
                {
                    numberRandomizer.SetRange(0, freeSpawnPositions.Count - 1);
                    SetPickUp(wwPrefab[size]);
                }
            }
        }

        private void SetPickUp(GameObject prefab){
            bool wwSpawned = false;
            while(!wwSpawned){
                var newSpot = GetRandomEmptySpot();
                if(newSpot == null) continue;
                Instantiate(prefab, newSpot);
                wwSpawned = true;
            }
        }

        private Transform GetRandomEmptySpot(){
            int newNumber = (int)numberRandomizer.GetRandom();
            Transform returnTransform = freeSpawnPositions[newNumber];
            freeSpawnPositions.RemoveAt(newNumber);
            return returnTransform;
        }

        public void DestroyPickUps(){
            foreach (var position in spawnPositions)
            {
                Destroy(position.GetChild(0).gameObject);
            }
        }
    }
}