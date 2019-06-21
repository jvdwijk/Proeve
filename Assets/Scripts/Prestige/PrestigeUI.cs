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

        private void Awake() {
            prestigePointsStat = playerStatsHandler.GetOrCreateStat(PlayerStatType.PrestigePoints);
            playerStatsHandler.GetOrCreateStat(stat).StatChanged += (clear) => UpdateCurrencyUI((int)playerStatsHandler.GetOrCreateStat(stat).Value);
            UpdateCurrencyUI((int) prestigePointsStat.Value);
        }

        private void OnEnable() {
            UpdateCurrencyUI((int) prestigePointsStat.Value);
        }

        public void UpdateCurrencyUI(int newValue) {
            prestigePointsDisplay.text = newValue.ToString();
        }


}
}