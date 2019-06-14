using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    /// <summary>
    /// Tracks a single stat
    /// </summary>
    /// <typeparam name="T">The enum this stat belongs to</typeparam>
    public class Stat<T> where T : Enum {
        private float value;
        private T statType;

        /// <summary>
        /// Called when the stats is changed
        /// </summary>
        public event Action<Stat<T>> StatChanged;

        /// <summary>
        /// The type of the stat
        /// </summary>
        public T StatType => statType;

        /// <summary>
        /// The current valie of the stat
        /// </summary>
        /// <value></value>
        public float Value {
            get { return this.value; }
            set { SetValue(value); }
        }

        public float PreviousValue { get; private set; }

        /// <summary>
        /// Sets the type of the stat
        /// </summary>
        /// <param name="statType">the new type</param>
        public void SetType(T statType) {
            this.statType = statType;
        }

        /// <summary>
        /// Sets the value of the stat
        /// </summary>
        /// <param name="value">the new value</param>
        public void SetValue(float value) {
            PreviousValue = value;
            this.value = value;
            StatChanged?.Invoke(this);
        }

    }
}