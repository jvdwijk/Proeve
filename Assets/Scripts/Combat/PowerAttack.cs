using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PeppaSquad.Spawning;
using PeppaSquad.Utils;

namespace PeppaSquad.Combat {
    /// <summary>
    /// Handles Powerattacks
    /// </summary>
    public class PowerAttack : SingleTargetAttack {

        [SerializeField]
        private GameObjectSpawner buttonSpawner;

        [SerializeField]
        private ComboCounter combo;
        private Coroutine SpawnComboButtonsRoutine;

        [SerializeField]
        private float buttonActiveTime, buttonSpawnDelay, comboDamageBoost;
        [SerializeField]
        private float StartDamageBoost;

        private Coroutine comboButtonSpawnRoutine;

        /// <summary>
        /// Executes a power attack.
        /// </summary>
        /// <param name="target">the target of the attack</param>
        public override void Attack(IDamagable target, HitDirection dir = 0) {
            combo.Increase();
            base.Attack(target, HitDirection.Front);
        }

        /// <summary>
        /// Calculates the damage of the power attack.
        /// </summary>
        /// <returns>power attack damage</returns>
        protected override int CalculateAttackDamage() {
            var damage = base.CalculateAttackDamage();
            damage += (int) ((float) damage * (StartDamageBoost + (combo.CurrentCombo * comboDamageBoost)));
            return damage;
        }

        /// <summary>
        /// Starts spawning power attack buttons
        /// </summary>
        public void StartSpawning() {
            comboButtonSpawnRoutine = StartCoroutine(SpawnComboButtons());
        }

        /// <summary>
        /// Stops spawning power attack buttons.
        /// </summary>
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

        /// <summary>
        /// Spawns a power attack button.
        /// </summary>
        private void SpawnButton() {
            buttonSpawner.Spawn(AddAttackToButton);
        }

        /// <summary>
        /// adds the "Attack" method tho the onclick event.
        /// </summary>
        /// <param name="buttonGameobject"></param>
        /// <returns></returns>
        private GameObject AddAttackToButton(GameObject buttonGameobject) {
            var button = buttonGameobject.GetComponentInChildren<Button>();
            button.onClick.AddListener(Attack);
            button.onClick.AddListener(() => {
                Destroy(buttonGameobject);
            });
            StartCoroutine(DestroyGameobject(buttonActiveTime, buttonGameobject));
            return buttonGameobject;
        }

        /// <summary>
        /// Coroutine which destroys a gameobject after a given amount of seconds.
        /// </summary>
        /// <param name="waitTime">delay before the object is destroyed</param>
        /// <param name="obj">object to be destroyed</param>
        /// <returns></returns>
        private IEnumerator DestroyGameobject(float waitTime, GameObject obj) {
            yield return new WaitForSeconds(waitTime);
            Destroy(obj);
            combo.ResetCombo();
        }

        /// <summary>
        /// Resets the combo
        /// </summary>
        public void Reset() {
            combo.ResetCombo();
        }

    }
}