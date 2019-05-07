using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PeppaSquad.UI
{
    public class HealthGUI : MonoBehaviour
    {
        [SerializeField]
        private Image healthBar;

        private int maxHealth = 100;

        public void ChangeHealth(int health){
            healthBar.fillAmount = (float) health / maxHealth;
        }

        public void SetMaxHealth(int health){
            maxHealth = health;
        }

        private IEnumerator HealthUpdate(){


            yield return null;
        }
    }
}
