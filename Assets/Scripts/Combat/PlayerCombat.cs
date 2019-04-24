using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PeppaSquad.Enemies;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        private Enemy currentEnemy;
        public Enemy CurrentEnemy{ get{ return currentEnemy; } set{ currentEnemy = value; }}
        
        private PlayerStatsHandler stats;

        private SingleTargetAttack[] attacks;
    }    
}
