using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resetter : MonoBehaviour {
    private event Action OnReset;

    /// <summary>
    /// The base function for resetting a class. Usually happens after the game ended
    /// </summary>
    public virtual void TriggerReset() {
        OnReset?.Invoke();
    }
}