using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Currency
{
    public class ActiveSwitch : MonoBehaviour
    {
        /// <summary>
        /// Switches the target object between active and inactive
        /// </summary>
        public void SwitchActive(GameObject target)
        {
            target.SetActive(!target.activeSelf);
        }
    }
}
