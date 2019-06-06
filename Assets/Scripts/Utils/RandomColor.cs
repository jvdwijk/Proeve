using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    /// <summary>
    /// Creates a random color
    /// </summary>
    public class RandomColor {

        private Color color;
        private bool randomizeAlpha;

        /// <summary>
        /// the random color
        /// </summary>
        public Color RandomizedColor => color;

        public RandomColor(bool alpha = false) {
            randomizeAlpha = alpha;
            Randomize();
        }

        /// <summary>
        /// Creates a random color.
        /// </summary>
        public void Randomize() {
            var r = Random.Range(0f, 1f);
            var g = Random.Range(0f, 1f);
            var b = Random.Range(0f, 1f);
            var a = randomizeAlpha ? Random.Range(0f, 1f) : 1;
            color = new Color(r, g, b, a);
        }

        /// <summary>
        /// Implicitly converts this class to the Color type
        /// </summary>
        /// <param name="randomColor">the random color to be converted</param>
        public static implicit operator Color(RandomColor randomColor) {
            return randomColor.color;
        }

    }
}