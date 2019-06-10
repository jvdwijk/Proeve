using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Pickups {
    public class PickupSpawner : Resetter {

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
    }
}