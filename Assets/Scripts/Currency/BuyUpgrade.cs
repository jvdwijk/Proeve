﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PeppaSquad.Currency
{
    public class BuyUpgrade : MonoBehaviour
    {
        [SerializeField] private PlayerCurrency playerCurrency;
        [SerializeField] private TMP_Text currentLevelText;
        [SerializeField] private TMP_Text upgradeCostText;
        private int upgradeCost;
        private int currentLevel;

        private void Start()
        {
            //After taking the saved stats, the values in the shop should update to stay consistent with that.
            UpdateText();

        }

        private void UpdateText()
        {
            upgradeCostText.text = upgradeCost.ToString();
            currentLevelText.text = currentLevel.ToString();
        }

        public void Upgrade()
        {
            if (playerCurrency.Currency >= upgradeCost)
            {
                playerCurrency.SubtractCurrency(upgradeCost);
                currentLevel += 1;
                upgradeCost = (currentLevel * 7 + (currentLevel / 3 * 10) + 5);
                UpdateText();
            }
            else
            {
                print("Not enough gold!");
                //Possibly play negative feedback sound and display something on screen?
            }
        }

    }
}
