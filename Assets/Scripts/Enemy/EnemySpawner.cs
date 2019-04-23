using System;
using UnityEngine;

using PeppaSquad.UI;

namespace PeppaSquad.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private Enemy[] enemyPrefabs;

        private Enemy[] bossPrefabs;

        private float spawnRadius = 5;

        private HealthGUI healthGUI;

        public event Action<Enemy> OnEnemySpawned;

        public void SpawnEnemy(){
            Enemy newEnemy = SpawnEntity(enemyPrefabs);
            InitEntity(newEnemy);
        }

        public void SpawnBoss(){
            Enemy newEnemy = SpawnEntity(bossPrefabs);
            InitEntity(newEnemy);
        }

        private Enemy SpawnEntity(Enemy[] prefabs){
            var enemyNumber = UnityEngine.Random.Range(0, prefabs.Length - 1);
            return Instantiate(prefabs[enemyNumber]);
        }

        private void InitEntity(Enemy enemy){
            
            enemy.OnHealthChanged += healthGUI.ChangeHealth;
            enemy.StartAttack();
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}