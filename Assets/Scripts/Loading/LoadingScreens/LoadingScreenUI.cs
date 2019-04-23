using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Loading;

namespace PeppaSquad.Loading.LoadingScreens
{
    public abstract class LoadingScreenUI : MonoBehaviour
    {
        /// <summary>
        /// Activates the loading screen.
        /// </summary>
        /// <param name="OnLoadingscreenActive"></param>
        public abstract void Activate(Action OnLoadingscreenActive = null);

        /// <summary>
        /// Deactivates the loading screen
        /// </summary>
        public abstract void Deactivate();

        public virtual void SetLoadingData(LoadData loaddata){}

    }
}


