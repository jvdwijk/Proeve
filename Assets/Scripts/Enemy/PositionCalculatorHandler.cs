using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Combat;
using PeppaSquad.Enemies;
using PeppaSquad.Spawning;
using PeppaSquad.Spawning.TransformCalculators.Base;

namespace PeppaSquad.Combat {
    public class PositionCalculatorHandler : MonoBehaviour {

        [SerializeField]
        private EnemySpawner spawner;

        [SerializeField]
        private GameObjectSpawner objectSpawner;

        [SerializeField]
        private PositionCalculator defaultCalculator;

        private void Awake() {
            spawner.OnEnemySpawned += SetPositionCalc;
        }

        private void SetPositionCalc(Enemy enemy) {
            var enemyCalc = enemy.GetComponent<PositionCalculator>();
            if (enemyCalc == null)
                enemyCalc = defaultCalculator;
            objectSpawner.SetPositionCalculator(enemyCalc);
        }

    }
}