using System;
using UnityEngine;

using PeppaSquad.UI;

namespace PeppaSquad.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Enemy[] enemyPrefabs;
        [SerializeField]
        private Enemy[] bossPrefabs;
        [SerializeField]
        private HealthGUI healthGUI;
        
        private float spawnRadius = 5;

        public event Action<Enemy> OnEnemySpawned;

        [ContextMenu("SpawnEnemy")]
        public void SpawnEnemy(){
            Enemy newEnemy = SpawnEntity(enemyPrefabs);
            InitEntity(newEnemy);
        }

        public void SpawnBoss(){
            Enemy newEnemy = SpawnEntity(bossPrefabs);
            InitEntity(newEnemy);
        }

        private Enemy SpawnEntity(Enemy[] prefabs){
            var enemyNumber = UnityEngine.Random.Range(0, prefabs.Length);
            return Instantiate(prefabs[enemyNumber]);
        }

        private void InitEntity(Enemy enemy){
            
            enemy.OnHealthChanged += healthGUI.ChangeHealth;
            enemy.StartAttack();
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}