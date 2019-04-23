using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Enemy
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        private int health;
        private int attackDPS;
        private IDamagable target;

        private Coroutine attackRoutine;

        public IDamagable Target => target;

        public event Action OnAttack;
        public event Action<int> OnHealthChanged;
        public event Action OnDeath;

        public void Init(int health = 100, int attackDPS = 10, IDamagable target = null)
        {
            this.health = health;
            this.attackDPS = attackDPS;
            this.target = target;
        }

        public void Damage(int amount)
        {
            health = -amount;
            if (health <= 0)
            {
                Die();
                return;
            }
            OnHealthChanged?.Invoke(health);
        }

        public void StartAttack()
        {
            attackRoutine = StartCoroutine(AttackRoutine());
        }

        private void Die()
        {
            StopCoroutine(attackRoutine);

            OnDeath?.Invoke();
            Destroy(gameObject);
        }

        private float RandomizeTime()
        {
            float time = UnityEngine.Random.Range(0.5f, 3f);
            return time;
        }

        private IEnumerator AttackRoutine()
        {
            while (target != null)
            {
                target.Damage(attackDPS);
                yield return new WaitForSeconds(RandomizeTime());
            }
            yield return null;
        }
    }
}
