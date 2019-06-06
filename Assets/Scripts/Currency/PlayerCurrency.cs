using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PeppaSquad.Stats.PlayerStats;
using PeppaSquad.Stats;
using PeppaSquad.Enemies;

namespace PeppaSquad.Currency
{
    public class PlayerCurrency : MonoBehaviour
    {
        [SerializeField]private int currency;
        public int Currency => currency;
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private EnemyTracker enemyTracker;
        [SerializeField] private TMP_Text currencyText;
        private Stat<PlayerStatType> statCurrency;

        /// <summary>
        /// This start is used to add updatecurrency to the onenemydefeat action. It also assigns a stattype to statcurrency
        /// </summary>
        private void Start()
        {
            statCurrency = playerStatsHandler.GetOrCreateStat(PlayerStatType.Currency);
            currency = (int)statCurrency.Value;
            enemyTracker.OnEnemyDefeat += () => UpdateCurrency(enemyTracker.EnemyLevel * 3);
        }

        /// <summary>
        /// Updates the players current amount of currency according to any negative/positive changes.
        /// </summary>
        /// <param name="updateAmount"></param>
        public void UpdateCurrency(int updateAmount)
        {
            currency += updateAmount;
            statCurrency.SetValue(currency);
            currencyText.text = currency.ToString();
        }
    }
}
