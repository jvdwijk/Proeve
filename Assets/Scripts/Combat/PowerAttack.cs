using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PeppaSquad.Spawning;

namespace PeppaSquad.Combat {
    public class PowerAttack : SingleTargetAttack {

        [SerializeField]
        private GameObjectSpawner buttonSpawner;

        private ComboCounter combo;
        private Coroutine SpawnComboButtonsRoutine;

        private void Awake() {
            combo = new ComboCounter();
        }

        public override void Attack(IDamagable target) {
            combo.Increase();
            var damage = damageCalculator.CalculateDamage();
        }

        private IEnumerator SpawnComboButtons() {
            while (true) {

                yield return null;
            }
        }

        private void SpawnButton() {
            buttonSpawner.Spawn(AddAttackToButton);
        }

        private GameObject AddAttackToButton(GameObject buttonGameobject) {
            var button = buttonGameobject.GetComponent<Button>();
            button.onClick.AddListener(Attack);
            return buttonGameobject;
        }

        public void Reset() {
            combo.ResetCombo();

        }

    }
}