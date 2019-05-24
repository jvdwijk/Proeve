using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PeppaSquad.Stats {
    public class ResettableStat<StatName> : Stat<StatName> where StatName : Enum {

        public virtual void Reset() {
            Value = 0;
        }
    }
}