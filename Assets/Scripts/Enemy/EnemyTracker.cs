﻿using System;
using System.Collections;
using System.Collections.Generic;
using PeppaSquad.Combat;
using UnityEngine;

namespace PeppaSquad.Enemies {
    public class EnemyTracker : MonoBehaviour {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private PlayerCombat playerCombat;

        private int enemyLevel;

        private Enemy currentEnemy;

        public event Action OnBossDefeat;

        public void StartSpawning () {
            SpawnEnemy ();
        }

        public void TriggerReset () {
            enemyLevel = 0;
            if (currentEnemy != null) Destroy (currentEnemy);
            currentEnemy = null;
        }

        private void SpawnEnemy () {
            //TODO System for choosing enemy or boss

            currentEnemy = enemySpawner.SpawnEnemy();
            currentEnemy.OnDeath += SpawnEnemy;

            playerCombat.CurrentEnemy = currentEnemy;
        }
    }
}