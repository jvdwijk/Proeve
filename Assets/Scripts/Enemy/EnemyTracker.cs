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

        private int enemyLevel;


        private Enemy currentEnemy;

        public int EnemyLevel => enemyLevel;

        public event Action OnEnemyDefeat;
        public event Action OnBossDefeat;
        
        public override void TriggerReset()
        {
            enemyLevel = 0;
            print(currentEnemy);
            if (currentEnemy != null) Destroy(currentEnemy.gameObject);
            currentEnemy = null;

            base.TriggerReset();
        }

        public void StartSpawning()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {

            //TODO System for choosing enemy or boss

            currentEnemy = enemySpawner.SpawnEnemy();
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