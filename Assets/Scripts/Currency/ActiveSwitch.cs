using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Currency
{
    public class ActiveSwitch : MonoBehaviour
    {
        public void SwitchActive(GameObject target)
        {
            target.SetActive(!target.activeSelf);
        }
    }
}
