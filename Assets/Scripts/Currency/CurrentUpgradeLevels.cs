using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Currency
{
    public class CurrentUpgradeLevels : MonoBehaviour
    {
        [SerializeField] private BuyUpgrade strengthUpgrade, speedUpgrade, timerUpgrade, comboUpgrade, respawnUpgrade;


        private int strengthLevel, speedLevel, timerLevel, comboLevel, respawnLevel;

        public int StrengthLevel => strengthLevel;
        public int SpeedLevel => speedLevel;
        public int TimerLevel => timerLevel;
        public int ComboLevel => comboLevel;
        public int RespawnLevel => respawnLevel;

        


        public void UpdateCurrentLevel(){
            strengthLevel = strengthUpgrade.Currentlevel;
            speedLevel = speedUpgrade.Currentlevel;
            timerLevel = timerUpgrade.Currentlevel;
            comboLevel = comboUpgrade.Currentlevel;
            respawnLevel = respawnUpgrade.Currentlevel;
        }

    }
}
