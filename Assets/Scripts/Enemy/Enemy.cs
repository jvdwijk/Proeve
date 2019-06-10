using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Enemies {
    public class Enemy : MonoBehaviour, IDamagable {
        private int health;

        [SerializeField]
        private Animator animator;

        private Dictionary<HitDirection, string> directionKeys = new Dictionary<HitDirection, string>() { { HitDirection.Left, "LeftStrike" }, { HitDirection.Right, "RightStrike" }, { HitDirection.Front, "FrontStrike" }
        };

        private string deathAnimationKey = "Died";

        public int Health { get { return health; } }

        public event Action<int> OnHealthChanged;
        public event Action OnDeath;

        public void Init(int health = 100) {
            this.health = health;
        }

        /// <summary>
        /// Damages the enemy, and checks if he still has health
        /// </summary>
        /// <param name="amount"></param>
        public void Damage(int amount, HitDirection dir = HitDirection.Default) {

            if (health == 0)
                return;

            health -= amount;
            health = Mathf.Clamp(health, 0, int.MaxValue);

            if (directionKeys.ContainsKey(dir) && animator != null) {
                var animationKey = directionKeys[dir];

                animator.SetTrigger(animationKey);
            }

            if (health <= 0) {
                StartDEath();
            }
            OnHealthChanged?.Invoke(health);
        }

        /// <summary>
        /// Destroys the enemy
        /// </summary>
        private void StartDEath() {
            StartCoroutine(DieRoutine());
        }

        private void Die() {
            DestroyImmediate(this.gameObject);
            OnDeath?.Invoke();
        }

        private IEnumerator DieRoutine() {
            if (animator == null) {
                Die();
                yield break;
            }

            animator.SetTrigger(deathAnimationKey);

            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("despawn")) {
                yield return null;
            }
            while (animator.GetCurrentAnimatorStateInfo(0).IsName("despawn") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) {
                yield return null;
            }
            Die();
        }
    }
}