using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    public class Stat<T> where T : Enum {
        private float value;
        private T statType;

        public event Action<Stat<T>> StatChanged;

        public T StatType => statType;
        public float Value {
            get { return this.value; }
            set { SetValue(value); }
        }

        public Stat(T statType) {
            this.statType = statType;
        }

        public void SetValue(float value) {
            this.value = value;
            StatChanged?.Invoke(this);
        }

    }
}