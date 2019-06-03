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
        private MapChanger mapChanger;

        [SerializeField]
        private Transform spawnPosition;

        public event Action<Enemy> OnEnemySpawned;

        /// <summary>
        /// Spawn and Init a new enemy
        /// </summary>
        /// <returns>the newly made enemy</returns>
        public Enemy SpawnEnemy() {
            Enemy newEnemy = SpawnEntity(enemyPrefabs);
            InitEntity(newEnemy);
            return newEnemy;
        }

        /// <summary>
        /// Spawns boss
        /// </summary>
        /// <returns></returns>
        public Enemy SpawnBoss() {
            Enemy newEnemy = SpawnEntity(bossPrefabs);
            InitEntity(newEnemy);
            newEnemy.OnDeath += mapChanger.ChangeMap;
            return newEnemy;
        }

        /// <summary>
        /// Spawn random enemy from array
        /// </summary>
        /// <param name="prefabs"></param>
        /// <returns></returns>
        private Enemy SpawnEntity(Enemy[] prefabs) {
            var enemyNumber = UnityEngine.Random.Range(0, prefabs.Length);
            return Instantiate(prefabs[enemyNumber]);
        }

        /// <summary>
        /// Sets position of enemy
        /// </summary>
        /// <param name="enemy"></param>
        private void InitEntity(Enemy enemy) {
            enemy.transform.parent = spawnPosition;
            enemy.transform.localPosition = Vector3.zero;
            enemy.transform.localRotation = Quaternion.identity;

            enemy.OnHealthChanged += healthGUI.ChangeHealth;
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}