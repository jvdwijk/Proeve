using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Combat;
using PeppaSquad.Enemies;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;

namespace PeppaSquad.GameFlow {
    public class GameManager : MonoBehaviour {

        [SerializeField]
        private EnemyTracker enemyTracker;

        [SerializeField]
        private PickupSpawner pickupHandler;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private GameObject pauseUI;

        [SerializeField]
        private PowerAttack comboAttack;

        [SerializeField]
        private Resetter[] resettables;

        [SerializeField]
        private MapChanger mapChanger;

        private float timeScaleOnPause;

        /// <summary>
        /// Triggers all the scripts needed to start the game.
        /// </summary>
        public void StartGame() {
            mapChanger.ChangeMap();
            enemyTracker.StartSpawning();
            timer?.StartTimer();
            pickupHandler?.StartSpawningPickups();
            comboAttack.Start();
        }

        /// <summary>
        /// Resets the given resettables to stop the game.
        /// </summary>
        public void ResetGame() {
            foreach (Resetter resettable in resettables) {
                resettable.TriggerReset();
            }
            comboAttack.Stop();
            timer.StopTimer();
        }

        /// <summary>
        /// stops the time to pause the game. 
        /// </summary>
        /// <param name="pause"></param>
        public void PauseGame(bool pause) {
            timer.Paused = pause;
            timeScaleOnPause = pause ? Time.timeScale : timeScaleOnPause;
            Time.timeScale = pause ? 0 : timeScaleOnPause;
            pauseUI.SetActive(pause);
        }
    }
}