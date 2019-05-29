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

        private float timeScaleOnPause;

        public void StartGame() {
            enemyTracker.StartSpawning();
            timer?.StartTimer();
            pickupHandler?.StartSpawningPickups();
            comboAttack.Start();
        }

        public void ResetGame() {
            foreach (Resetter resettable in resettables) {
                resettable.TriggerReset();
            }
            comboAttack.Stop();
        }

        public void PauseGame(bool pause) {
            timer.Paused = pause;
            timeScaleOnPause = pause ? Time.timeScale : timeScaleOnPause;
            Time.timeScale = pause ? 0 : timeScaleOnPause;
            pauseUI.SetActive(pause);
            //Todo Pause Combat
        }
    }
}