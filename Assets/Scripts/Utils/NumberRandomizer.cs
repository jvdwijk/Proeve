using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    /// <summary>
    /// A range of values between 2 numbers
    /// </summary>
    [Serializable]
    public class NumberRange {

        [SerializeField]
        private float min, max;

        /// <summary>
        /// The minimun amount in the range
        /// </summary>
        /// <value>new minimum value</value>
        public float Min {
            get { return min; }
            set { SetRange(value, max); }
        }
        /// <summary>
        /// The maximum amount in the range
        /// </summary>
        /// <value>new maximum value</value>
        public float Max {
            get { return max; }
            set { SetRange(min, value); }
        }

        /// <summary>
        /// Called when the numberrange chaned
        /// </summary>
        public event Action<NumberRange> RangeChanged;

        public NumberRange(float min, float max) {
            SetRange(min, max);
        }

        /// <summary>
        /// Sets new values for the numberrange
        /// </summary>
        /// <param name="min">new min value</param>
        /// <param name="max">new max value</param>
        public void SetRange(float min, float max) {
            if (min > max)
                max = min;

            if (this.min == min && this.max == max)
                return;

            this.min = min;
            this.max = max;
            RangeChanged?.Invoke(this);
        }

        /// <summary>
        /// Set the min and max to the same value
        /// </summary>
        /// <param name="range">the given value</param>
        public void SetRange(float range) {
            if (this.min == range && this.max == range)
                return;

            this.min = range;
            this.max = range;
            RangeChanged?.Invoke(this);
        }

        /// <summary>
        /// Returns a random value within the set range
        /// </summary>
        /// <returns>a random value within the set range</returns>
        public float GetRandom() {
            return UnityEngine.Random.Range(min, max);
        }

    }
}