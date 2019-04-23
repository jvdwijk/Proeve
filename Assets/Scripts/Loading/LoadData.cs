using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Loading
{
    public abstract class LoadData
    {
        public float Progress => GetProgress();
        public bool IsReady => IsReadyCheck();

        protected abstract float GetProgress();

        protected abstract bool IsReadyCheck();
    }
}


