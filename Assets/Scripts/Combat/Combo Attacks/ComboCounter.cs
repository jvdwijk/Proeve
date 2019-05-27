using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter {

    private int currentCombo;
    private int highestCombo;

    public int CurrentCombo => currentCombo;
    public int HighestCombo => highestCombo;

    public event Action<ComboCounter> ComboChanged;
    public event Action<ComboCounter> HighestComboChanged;

    public void Increase() {
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