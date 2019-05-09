using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Combat;
using PeppaSquad.Score;
using PeppaSquad.Utils;

namespace PeppaSquad.Enemies {
    public class EnemyTracker : MonoBehaviour {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private PlayerCombat playerCombat;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private EnemyHealthCalculator healthCalculator;

        private int enemyLevel;

        private Enemy currentEnemy;

        public event Action OnBossDefeat;

        public void StartSpawning() {
            SpawnEnemy();
        }

        public void TriggerReset() {
            enemyLevel = 0;
            if (currentEnemy != null) Destroy(currentEnemy);
            currentEnemy = null;
        }

        private void SpawnEnemy() {

            //TODO System for choosing enemy or boss

            currentEnemy = enemySpawner.SpawnEnemy();
            int health = healthCalculator.GetHealth(enemyLevel);
            currentEnemy.Init(health);
            currentEnemy.OnDeath += SpawnEnemy;

            timer.ResetTimer();

            playerCombat.CurrentEnemy = currentEnemy;
            enemyLevel++;
            ScoreHandlerSingleton.Instance?.SetScore(enemyLevel);
        }
    }
}