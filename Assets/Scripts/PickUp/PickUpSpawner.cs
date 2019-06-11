using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PeppaSquad.Utils;

namespace PeppaSquad.Pickups {
    public class PickupSpawner : Resetter {
        
        [SerializeField]
        private NumberRange numberRandomizer;

        [SerializeField]
        private GameObject redWWPrefab, yellowWWPrefab, blueWWPrefab;

        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private int redAmount, yellowAmount, blueAmount;

        public override void TriggerReset () {
            DestroyPickUps();
            base.TriggerReset();
        }

        public void SpawnPickups () {

            throw new System.NotImplementedException ();
        }

        public void DestroyPickUps(){
            foreach (var position in spawnPositions)
            {
                Destroy(position.GetChild(0).gameObject);
            }
        }

        private int GetRandomEmptySpot(){
            int newNumber = (int)numberRandomizer.GetRandom();
            if(spawnPositions[newNumber].childCount > 0) return -1;
            return newNumber;
        }
    }
}