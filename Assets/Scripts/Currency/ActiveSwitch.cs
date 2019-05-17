using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Currency
{
    public class ActiveSwitch : MonoBehaviour
    {
        public void SwitchActive(GameObject target)
        {
            if (target.activeSelf)
            {
                target.SetActive(false);
                print("activate");
            }
            else if (!target.activeSelf)
            {
                target.SetActive(true);
                print("sadtivate");
            }
        }
    }
}
