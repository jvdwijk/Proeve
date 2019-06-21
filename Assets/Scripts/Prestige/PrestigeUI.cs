using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;
using TMPro;

namespace PeppaSquad.Prestige{
public class PrestigeUI : MonoBehaviour
{
    [SerializeField] private LifePrestiger lifePrestiger;
    [SerializeField] private PlayerStatType stat;
    [SerializeField] private TextMeshProUGUI prestigePointsDisplay;
    [SerializeField] private PlayerStatsHandler playerStatsHandler;
    private Stat<PlayerStatType> prestigePointsStat;

        /// <summary>
        /// Getting the prestige point stat to display it to the player in the store UI, making sure it updates whenever the stat is changed.
        /// Also getting rid of the playerstattype that statchanged gives.
        /// </summary>
        private void Awake() {
            prestigePointsStat = playerStatsHandler.GetOrCreateStat(PlayerStatType.PrestigePoints);
            playerStatsHandler.GetOrCreateStat(stat).StatChanged += (clear) => UpdateCurrencyUI((int)playerStatsHandler.GetOrCreateStat(stat).Value);
            UpdateCurrencyUI((int) prestigePointsStat.Value);
        }

        /// <summary>
        /// Making sure the UI displays the correct value when the object is enabled.
        /// </summary>
        private void OnEnable() {
            UpdateCurrencyUI((int) prestigePointsStat.Value);
        }

        /// <summary>
        /// Updating the UI
        /// </summary>
        public void UpdateCurrencyUI(int newValue) {
            prestigePointsDisplay.text = newValue.ToString();
        }


}
}