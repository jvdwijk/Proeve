using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Enemies {
    [System.Serializable]
    public class EnemyHealthCalculator {

        [SerializeField]
        private int startHealth = 10;

        [SerializeField]
        private float power = 1.3f;

        public int GetHealth(int enemyLevel) {
            int health = 10;
            health += (int) Mathf.Pow((float) enemyLevel, power);
            return health;
        }

    }
}