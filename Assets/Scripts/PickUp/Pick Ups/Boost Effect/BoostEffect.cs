using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Pickups.Effects {
    /// <summary>
    /// Effect to be executed on picking up pickup
    /// </summary>
    public abstract class BoostEffect : MonoBehaviour {

        /// <summary>
        /// the boost effect
        /// </summary>
        public abstract void Boost();

    }
}