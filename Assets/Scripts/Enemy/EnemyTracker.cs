using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using PeppaSquad.Combat;

namespace PeppaSquad.Enemies
{
    public class EnemyTracker : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private PlayerCombat playerCombat;

        private int enemyLevel;

        private Enemy currentEnemy;

        private event Action OnBossDefeat;

        public void Awake(){
            SpawnEnemy();
        }

        public void TriggerReset(){
            enemyLevel = 0;
            currentEnemy.Damage(currentEnemy.Health);
            currentEnemy = null;
        }

        private void SpawnEnemy(){
            //TODO System for choosing enemy or boss

            currentEnemy = enemySpawner.SpawnEnemy();
            currentEnemy.OnDeath += SpawnEnemy;

            playerCombat.CurrentEnemy?.Damage(currentEnemy.Health);

            playerCombat.CurrentEnemy = currentEnemy;
        }
    }    
}