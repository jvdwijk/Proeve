using System.Collections;
using System.Collections.Generic;
using PeppaSquad.Enemies;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;
using UnityEngine;

namespace PeppaSquad.GameFlow {
    public class GameManager : MonoBehaviour {

        [SerializeField]
        private EnemyTracker enemyTracker;

        [SerializeField]
        private PickupSpawner pickupHandler;

        [SerializeField]
        private Timer timer;

        public void StartGame () {
            enemyTracker.StartSpawning ();
            timer?.StartTimer ();
            pickupHandler?.StartSpawningPickups ();
        }

        public void ResetGame () {
            throw new System.NotImplementedException ();
        }

        public void PauseGame () {
            timer.Paused = true;

            //Todo Pause Combat
        }
    }
}