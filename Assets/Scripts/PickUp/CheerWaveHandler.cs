using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Pickups.Animations {
    public class CheerWaveHandler : MonoBehaviour {
        [SerializeField]
        private PickupCheerAnimationHandler animationHandler;

        [SerializeField]
        private CheerWaveHandler[] nextCheer;

        [SerializeField]
        private float waveDelayTime;

        [ContextMenu("Start Wave")]
        public void StartWave() {
            Wave(0);
        }

        public void Wave(int wavenumber) {
            StartCoroutine(WaveRoutine(waveDelayTime * wavenumber));
            foreach (var cheerer in nextCheer) {
            cheerer.Wave(wavenumber + 1);
            }

        }

        private IEnumerator WaveRoutine(float cheerTime) {
            yield return new WaitForSeconds(cheerTime);
            animationHandler.Cheer();
        }

    }
}