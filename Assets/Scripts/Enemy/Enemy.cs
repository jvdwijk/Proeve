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
        
        /// <summary>
        /// Damages the enemy, and checks if he still has health
        /// </summary>
        /// <param name="amount"></param>
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

        /// <summary>
        /// Destroys the enemy
        /// </summary>
        private void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
