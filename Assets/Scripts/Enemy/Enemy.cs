using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Enemies
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        private int health;

        public int Health { get { return health; } }

        public event Action<int> OnHealthChanged;
        public event Action OnDeath;

        public void Init(int health = 100)
        {
            this.health = health;
        }

        public void Damage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
                return;
            }
            OnHealthChanged?.Invoke(health);
        }

        private void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
