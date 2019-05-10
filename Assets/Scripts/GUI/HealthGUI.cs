﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PeppaSquad.UI{
    public class HealthGUI : MonoBehaviour{
        [SerializeField]
        private Image healthBar;

        [SerializeField]
        private float speed = 1;

        private int maxHealth = 100;

        private float currentGoal;
        private Coroutine healthCoroutine;

        public void ChangeHealth(int health){
            currentGoal = (float) health / maxHealth;
            if(healthCoroutine == null) healthCoroutine = StartCoroutine(HealthUpdate());
        }

        public void SetMaxHealth(int health){
            maxHealth = health;
            healthBar.fillAmount = currentGoal;
        }

        private IEnumerator HealthUpdate(){
            while (healthBar.fillAmount != currentGoal){
                healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentGoal, Time.deltaTime * speed);
                yield return null;
            }
            healthBar.fillAmount = currentGoal;
        }
    }
}