using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Combat;
using PeppaSquad.Enemies;
using PeppaSquad.Pickups;
using PeppaSquad.Utils;

namespace PeppaSquad.GameFlow {
    public class GameManager : StateMachine<GameStateType> {

        [SerializeField]
        private GameStateType initialState;

        [SerializeField]
        private GameState[] states;

        private void Awake() {
            foreach (var state in states) {
                AddState(state.StateName, state);
            }
            SetState(initialState);
        }

        [SerializeField]
        private EnemyTracker enemyTracker;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private GameObject pauseUIMenu,
        pauseUIButton,
        pauseBlockUI,
        scanUI;

        [SerializeField]
        private PowerAttack comboAttack;

        [SerializeField]
        private Resetter[] resettables;

        [SerializeField]
        private MapChanger mapChanger;

        private float timeScaleOnPause;

        public bool MarkerTracked { get; private set; } = false;
        public bool GamePaused { get; private set; } = false;
        public bool GameRunning { get; private set; } = false;

        public event Action<bool> OnMarkerTrakedChanged;

        public void SetMarkerScanned(bool markerScanned) {
            if (markerScanned == MarkerTracked)
                return;

            MarkerTracked = markerScanned;
            OnMarkerTrakedChanged?.Invoke(markerScanned);
        }

        /// <summary>
        /// Triggers all the scripts needed to start the game.
        /// </summary>
        public void StartGame() {
            GameRunning = true;
            mapChanger.ChangeMap();
            enemyTracker.StartSpawning();
            timer?.StartTimer();
            comboAttack.Start();
        }

        /// <summary>
        /// Resets the given resettables to stop the game.
        /// </summary>
        public void ResetGame() {
            GameRunning = false;
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

            if (pause == GamePaused)
                return;

            GamePaused = pause;
            timer.Paused = pause;
            timeScaleOnPause = pause ? Time.timeScale : timeScaleOnPause;
            Time.timeScale = pause ? 0 : timeScaleOnPause;
        }
    }
}