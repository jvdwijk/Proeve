using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Combat;
using PeppaSquad.Score;
using PeppaSquad.Utils;
using PeppaSquad.UI;

namespace PeppaSquad.Enemies
{
    public class EnemyTracker : Resetter
    {
        [SerializeField]
        private EnemySpawner enemySpawner;
        [SerializeField]
        private PlayerCombat playerCombat;
        [SerializeField]
        private HealthGUI healthGUI;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private EnemyHealthCalculator healthCalculator;

        private int enemyLevel = 1;

        private Enemy currentEnemy;

        public int EnemyLevel => enemyLevel;

        public event Action OnEnemyDefeat;
        public event Action OnBossDefeat;
        
        public override void TriggerReset()
        {
            enemyLevel = 1;
            if (currentEnemy != null) Destroy(currentEnemy.gameObject);
            currentEnemy = null;

            base.TriggerReset();
        }

        public void StartSpawning()
        {
            SpawnEnemy();
        }

        /// <summary>
        /// Decides wether to spawn enemy or boss and inits it.
        /// </summary>
        private void SpawnEnemy()
        {

            currentEnemy = enemyLevel % 5 == 0 ? enemySpawner.SpawnBoss() : enemySpawner.SpawnEnemy();
            
            int health = healthCalculator.CalculateHealth(enemyLevel);
            currentEnemy.Init(health);
            healthGUI.SetMaxHealth(currentEnemy.Health);
            healthGUI.ChangeHealth(currentEnemy.Health);

            currentEnemy.OnDeath += OnEnemyDefeat;
            currentEnemy.OnDeath += SpawnEnemy;


            timer.ResetTimer();

            playerCombat.CurrentEnemy = currentEnemy;

            enemyLevel++;
            ScoreHandlerSingleton.Instance?.SetScore(enemyLevel);
        }
    }
}