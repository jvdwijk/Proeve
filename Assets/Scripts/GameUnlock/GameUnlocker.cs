using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PeppaSquad.Utils;

namespace PeppaSquad.GameFlow {
    public class GameUnlocker : MonoBehaviour {
        private const string gameUnlockKey = "Game Unlocked";

        [SerializeField]
        private string sceneName;

        /// <summary>
        /// Called on game unlock
        /// </summary>
        public event Action OnUnlocked;

        private void Awake() {
            OnUnlocked += LoadNextScene;
            var unlocked = BoolPlayerPrefs.GetBool(gameUnlockKey);

            if (unlocked)
                OnUnlocked?.Invoke();
        }

        /// <summary>
        /// Unlocks the game
        /// </summary>
        public void Unlock() {
            BoolPlayerPrefs.SetBool(gameUnlockKey, true);
            OnUnlocked?.Invoke();
        }

        /// <summary>
        /// Loads the next scene
        /// </summary>
        private void LoadNextScene() {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// Locks the game.
        /// </summary>
        [ContextMenu("Reset Unlock")]
        private void ResetGameUnlock() {
            BoolPlayerPrefs.SetBool(gameUnlockKey, false);
        }

    }
}