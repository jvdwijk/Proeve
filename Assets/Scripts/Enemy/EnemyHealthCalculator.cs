using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Enemies {
    [System.Serializable]
    public class EnemyHealthCalculator {

        [SerializeField]
        private int startHealth = 120;

        [SerializeField]
        private float power = 8f;

        /// <summary>
        /// Calculates the health of the new enemy with its level
        /// </summary>
        /// <param name="enemyLevel"></param>
        /// <returns></returns>
        public int CalculateHealth(int enemyLevel) {
            int health = startHealth;
            health += (int) Mathf.Pow((float) enemyLevel, power);
            return health;
        }

    }
}