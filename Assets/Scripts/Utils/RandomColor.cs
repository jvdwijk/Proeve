using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    public class RandomColor {

        private Color color;
        private bool randomizeAlpha;

        public Color RandomizedColor => color;

        public RandomColor(bool alpha = false) {
            randomizeAlpha = alpha;
            Randomize();
        }

        public void Randomize() {
            var r = Random.Range(0f, 1f);
            var g = Random.Range(0f, 1f);
            var b = Random.Range(0f, 1f);
            var a = randomizeAlpha ? Random.Range(0f, 1f) : 1;
            color = new Color(r, g, b, a);
        }

        public static implicit operator Color(RandomColor randomColor) {
            return randomColor.color;
        }

    }
}