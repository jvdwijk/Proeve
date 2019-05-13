using System;
using PeppaSquad.UI;
using UnityEngine;

namespace PeppaSquad.Enemies {
    public class EnemySpawner : MonoBehaviour {
        [SerializeField]
        private Enemy[] enemyPrefabs;
        [SerializeField]
        private Enemy[] bossPrefabs;
        [SerializeField]
        private HealthGUI healthGUI;

        [SerializeField]
        private Transform spawnPosition;

        public event Action<Enemy> OnEnemySpawned;

        public Enemy SpawnEnemy() {
            Enemy newEnemy = SpawnEntity(enemyPrefabs);
            InitEntity(newEnemy);
            return newEnemy;
        }

        public Enemy SpawnBoss() {
            Enemy newEnemy = SpawnEntity(bossPrefabs);
            InitEntity(newEnemy);
            return newEnemy;
        }

        private Enemy SpawnEntity(Enemy[] prefabs) {
            var enemyNumber = UnityEngine.Random.Range(0, prefabs.Length);
            return Instantiate(prefabs[enemyNumber]);
        }

        private void InitEntity(Enemy enemy) {
            enemy.transform.parent = spawnPosition;
            enemy.transform.localPosition = Vector3.zero;
            enemy.transform.localRotation = Quaternion.identity;

            enemy.OnHealthChanged += healthGUI.ChangeHealth;
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}