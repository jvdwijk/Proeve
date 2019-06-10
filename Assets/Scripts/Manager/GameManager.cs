using System;
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
        private PickupsHandler pickupHandler;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private GameObject pauseUIMenu, pauseUIButton, pauseBlockUI, scanUI;

        [SerializeField]
        private PowerAttack comboAttack;

        [SerializeField]
        private Resetter[] resettables;

        [SerializeField]
        private MapChanger mapChanger;

        private float timeScaleOnPause;

        private bool markerScanned, gameRunning = false;

        public void UserStartedGame() {
            StartCoroutine(ScanForMarker(() => {
                StartGame();
            }));
        }

        public void SetMarkerScanned(bool markerScanned) {
            this.markerScanned = markerScanned;

            if (!markerScanned && gameRunning) {
                PausesGame(true);
                pauseUIButton.SetActive(false);
                StartCoroutine(ScanForMarker(() => {
                    PausesGame(false);
                    pauseUIButton.SetActive(true);
                }));
            }
        }

        /// <summary>
        /// Triggers all the scripts needed to start the game.
        /// </summary>
        public void StartGame() {
            gameRunning = true;
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
            gameRunning = false;
            print("Resetin");
            foreach (Resetter resettable in resettables) {
                resettable.TriggerReset();
            }
            comboAttack.Stop();
            timer.StopTimer();
        }

        private void PausesGame(bool pause) {
            timer.Paused = pause;
            timeScaleOnPause = pause ? Time.timeScale : timeScaleOnPause;
            Time.timeScale = pause ? 0 : timeScaleOnPause;
            pauseBlockUI.SetActive(pause);
        }

        /// <summary>
        /// stops the time to pause the game. 
        /// </summary>
        /// <param name="pause"></param>
        public void UserPauseGame(bool pause) {
            PausesGame(pause);
            pauseUIMenu.SetActive(pause);
        }

        private IEnumerator ScanForMarker(Action onmarkerScanned) {
            scanUI.SetActive(true);
            while (!markerScanned)
                yield return null;

            scanUI.SetActive(false);
            onmarkerScanned?.Invoke();
        }
    }
}