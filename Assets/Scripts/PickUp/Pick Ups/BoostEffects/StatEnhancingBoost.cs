using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatEnhancingBoost : BoostEffect {
    [SerializeField]
    private BoostStatHandler stats;

    [SerializeField]
    private BoostType statType;

    public override void Boost() {
        var stat = stats.GetOrCreateStat(statType);
        stat.Value++;
    }
}