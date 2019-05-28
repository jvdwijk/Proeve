using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    [Serializable]
    public class NumberRange {

        [SerializeField]
        private float min, max;

        public float Min {
            get { return min; }
            set { SetRange(value, max); }
        }

        public float Max {
            get { return max; }
            set { SetRange(min, value); }
        }

        public event Action<NumberRange> RangeChanged;

        public NumberRange(float min, float max) {
            SetRange(min, max);
        }

        public void SetRange(float min, float max) {
            if (min > max)
                max = min;

            if (this.min == min && this.max == max)
                return;

            this.min = min;
            this.max = max;
            RangeChanged?.Invoke(this);
        }

        public void SetRange(float range) {
            if (this.min == range && this.max == range)
                return;

            this.min = range;
            this.max = range;
            RangeChanged?.Invoke(this);
        }

        public float GetRandom() {
            return UnityEngine.Random.Range(min, max);
        }

    }
}