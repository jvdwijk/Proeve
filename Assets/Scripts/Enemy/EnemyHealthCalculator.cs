using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Enemies {
    [System.Serializable]
    public class EnemyHealthCalculator {

        [SerializeField]
        private int startHealth = 20;

        [SerializeField]
        private float power = 3f;

        /// <summary>
        /// Calculates the health of the new enemy with its level
        /// </summary>
        /// <param name="enemyLevel"></param>
        /// <returns></returns>
        public int CalculateHealth(int enemyLevel) {
            int health = 10;
            health += (int) Mathf.Pow((float) enemyLevel, power);
            return health;
        }

    }
}