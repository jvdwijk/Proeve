using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    /// <summary>
    /// Tracks the combo.
    /// </summary>
    public class ComboCounter : MonoBehaviour {

        [SerializeField]
        private int maxCombo = 0;

        private int currentCombo = 0;
        private int highestCombo = 0;

        public int CurrentCombo => currentCombo;
        public int HighestCombo => highestCombo;

        /// <summary>
        /// Called when the current combo changed.
        /// </summary>
        public event Action<ComboCounter> ComboChanged;

        /// <summary>
        /// Called when a new highscore has been set.
        /// </summary>
        public event Action<ComboCounter> HighestComboChanged;

        /// <summary>
        /// Increases the combo by 1;
        /// </summary>
        public void Increase() {
            if (maxCombo > 0 && currentCombo >= maxCombo)
                return;
            currentCombo++;
            if (currentCombo > highestCombo) {
                highestCombo = currentCombo;
                HighestComboChanged?.Invoke(this);
            }
            ComboChanged?.Invoke(this);
        }

        /// <summary>
        /// Decreases the combo by 1;
        /// </summary>
        public void Decrease() {
            if (currentCombo < 1)
                return;

            currentCombo--;
            ComboChanged?.Invoke(this);
        }

        /// <summary>
        /// Resets the combo to it's starting value (0).
        /// </summary>
        public void ResetCombo() {
            if (currentCombo == 0)
                return;

            currentCombo = 0;
            ComboChanged?.Invoke(this);
        }

    }
}