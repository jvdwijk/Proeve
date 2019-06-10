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

            if (directionKeys.ContainsKey(dir)) {
                var animationKey = directionKeys[dir];

                animator.SetTrigger(animationKey);
            }

            health -= amount;
            if (health <= 0) {
                Die();
                return;
            }
            OnHealthChanged?.Invoke(health);
        }

        /// <summary>
        /// Destroys the enemy
        /// </summary>
        private void Die() {
            StartCoroutine(DieRoutine());
        }

        private IEnumerator DieRoutine() {
            animator.SetTrigger(deathAnimationKey);

            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("despawn")) {
                yield return null;
            }

            while (animator.GetCurrentAnimatorStateInfo(0).IsName("despawn") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 1) {
                print(animator.GetCurrentAnimatorStateInfo(0).normalizedTime + "  " + animator.GetCurrentAnimatorStateInfo(0).IsName("despawn"));
                yield return null;
            }
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}