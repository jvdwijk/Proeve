using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups.Stats;
using PeppaSquad.Stats.PlayerStats;

public class AttackDamageCalculator : MonoBehaviour {

    [SerializeField]
    private PlayerStatsHandler playerStats;

    [SerializeField]
    private BoostStatHandler boostStats;

    [SerializeField]
    private int baseDamage = 5;

    public int CalculateDamage() {
        var playerDamageLevel = playerStats.GetOrCreateStat(PlayerStatType.Damage);
        var damageBoostLevel = boostStats.GetOrCreateStat(BoostType.Damage);

        int attackDamage = baseDamage + Mathf.RoundToInt(3.5f * playerDamageLevel.Value) + Mathf.RoundToInt(2 * damageBoostLevel.Value);

        return attackDamage;

    }

}