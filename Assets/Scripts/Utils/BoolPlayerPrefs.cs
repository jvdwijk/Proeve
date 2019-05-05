using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Utils {
    public class BoolPlayerPrefs : PlayerPrefs {
        private const string boolPrefix = "__bool__";

        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetBool(string key, bool value) {
            var intValue = value ? 1 : 0;
            PlayerPrefs.SetInt($"{boolPrefix}{key}", intValue);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetBool(string key) {
            var intValue = GetInt(key);
            return intValue > 0;
        }
    }
}