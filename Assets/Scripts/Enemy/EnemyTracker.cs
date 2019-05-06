using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Combat;
using PeppaSquad.Utils;

namespace PeppaSquad.Enemies {
    public class EnemyTracker : MonoBehaviour {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private PlayerCombat playerCombat;

        [SerializeField]
        private Timer timer;

        private int enemyLevel;

        private Enemy currentEnemy;

        private event Action OnBossDefeat;

        public void Awake() { //TODO Change to StartSpawning() when GameManager is made.
            SpawnEnemy();
        }

        public void TriggerReset() {
            enemyLevel = 0;
            currentEnemy.Damage(currentEnemy.Health);
            currentEnemy = null;
        }

        private void SpawnEnemy() {
            //TODO System for choosing enemy or boss

            currentEnemy = enemySpawner.SpawnEnemy();
            currentEnemy.Init();
            currentEnemy.OnDeath += SpawnEnemy;

            timer.ResetTimer();

            playerCombat.CurrentEnemy = currentEnemy;
        }
    }
}