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
        private Transform[] spawnPositions;

        [SerializeField]
        private GameObject[] wwPrefab;

        [SerializeField]
        private int[] colorAmount;

        public void SpawnPickups () {
            numberRandomizer.SetRange(0, spawnPositions.Length - 1);

            for (int size = 0; size < colorAmount.Length; size++)
            {
                for (int pickUp = 0; pickUp < colorAmount[size]; pickUp++)
                {
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
            
            return spawnPositions[newNumber].childCount == 0 ? spawnPositions[newNumber] : null;
        }

        public void DestroyPickUps(){
            foreach (var position in spawnPositions)
            {
                Destroy(position.GetChild(0).gameObject);
            }
        }
    }
}