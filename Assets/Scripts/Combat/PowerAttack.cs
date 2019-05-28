using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PeppaSquad.Spawning;

namespace PeppaSquad.Combat {
    public class PowerAttack : SingleTargetAttack {

        [SerializeField]
        private GameObjectSpawner buttonSpawner;

        [SerializeField]
        private ComboCounter combo;
        private Coroutine SpawnComboButtonsRoutine;

        [SerializeField]
        private float buttonActiveTime = 2, buttonSpawnDelay = 8, comboDamageBoost = 10;
        [SerializeField]
        private float StartDamageBoost = 5;

        private Coroutine comboButtonSpawnRoutine;

        public override void Attack(IDamagable target) {
            combo.Increase();
            base.Attack(target);
        }

        protected override int CalculateAttackDamage() {
            var damage = base.CalculateAttackDamage();
            damage += (int) (((float) damage / comboDamageBoost) * ((float) combo.CurrentCombo + StartDamageBoost));
            return damage;
        }

        public void Start() {
            comboButtonSpawnRoutine = StartCoroutine(SpawnComboButtons());
        }

        public void Stop() {
            if (comboButtonSpawnRoutine == null)
                return;
            StopCoroutine(comboButtonSpawnRoutine);
            combo.ResetCombo();
        }

        private IEnumerator SpawnComboButtons() {
            while (true) {
                SpawnButton();
                yield return new WaitForSeconds(buttonSpawnDelay);
            }
        }

        private void SpawnButton() {
            buttonSpawner.Spawn(AddAttackToButton);
        }

        private GameObject AddAttackToButton(GameObject buttonGameobject) {
            var button = buttonGameobject.GetComponentInChildren<Button>();
            button.onClick.AddListener(Attack);
            button.onClick.AddListener(() => {
                Destroy(buttonGameobject);
            });
            StartCoroutine(DestroyGameobject(buttonActiveTime, buttonGameobject));
            return buttonGameobject;
        }

        private IEnumerator DestroyGameobject(float waitTime, GameObject obj) {
            yield return new WaitForSeconds(waitTime);
            Destroy(obj);
            combo.ResetCombo();
        }

        public void Reset() {
            combo.ResetCombo();
        }

    }
}