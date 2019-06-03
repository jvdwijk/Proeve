using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PeppaSquad.Stats {

    /// <summary>
    /// A resetable version of the stat class
    /// </summary>
    /// <typeparam name="StatName">The enum this stat belongs to</typeparam>
    public class ResettableStat<StatName> : Stat<StatName> where StatName : Enum {

        /// <summary>
        /// Resets the stat value to it's default value (0)
        /// </summary>
        public virtual void Reset() {
            Value = 0;
        }
    }
}