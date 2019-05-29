using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    public class ComboCounter : MonoBehaviour {

        [SerializeField]
        private int maxCombo = 0;

        private int currentCombo = 0;
        private int highestCombo = 0;

        public int CurrentCombo => currentCombo;
        public int HighestCombo => highestCombo;

        public event Action<ComboCounter> ComboChanged;
        public event Action<ComboCounter> HighestComboChanged;

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

        public void Decrease() {
            if (currentCombo < 1)
                return;

            currentCombo--;
            ComboChanged?.Invoke(this);
        }

        public void ResetCombo() {
            if (currentCombo == 0)
                return;

            currentCombo = 0;
            ComboChanged?.Invoke(this);
        }

    }
}