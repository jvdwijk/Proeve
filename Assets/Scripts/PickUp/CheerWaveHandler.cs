using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Pickups.Animations {
    /// <summary>
    /// Makes WWs do da wave!!
    /// </summary>
    public class CheerWaveHandler : MonoBehaviour {
        [SerializeField]
        private PickupCheerAnimationHandler animationHandler;

        [SerializeField]
        private CheerWaveHandler[] nextCheer;

        [SerializeField]
        private float waveDelayTime;

        /// <summary>
        /// Start the wave!
        /// </summary>
        [ContextMenu("Start Wave")]
        public void StartWave() {
            Wave(0);
        }

        /// <summary>
        /// Continues the wave!!
        /// </summary>
        /// <param name="wavenumber"></param>
        public void Wave(int wavenumber) {
            StartCoroutine(WaveRoutine(waveDelayTime * wavenumber));
            foreach (var cheerer in nextCheer) {
            cheerer.Wave(wavenumber + 1);
            }

        }

        /// <summary>
        /// Waits for their time to do the wave!!
        /// </summary>
        /// <param name="cheerTime"></param>
        /// <returns></returns>
        private IEnumerator WaveRoutine(float cheerTime) {
            yield return new WaitForSeconds(cheerTime);
            animationHandler.Cheer();
        }

    }
}