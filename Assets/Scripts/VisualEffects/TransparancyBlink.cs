using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PeppaSquad.VisualEffects.UI {
    public class TransparancyBlink : MonoBehaviour {

        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField, Range(0, 1)]
        private float minTranseparancy, maxTranseparancy;

        [SerializeField]
        private float lerpSpeed, maxLerpDiffrence;

        private void Awake() {
            StartEffect();
        }

        public void StartEffect() {
            StartCoroutine(StartBlinking());
        }

        private IEnumerator StartBlinking() {
            while (true) {
                yield return StartCoroutine(BlinkTowards(minTranseparancy));
                yield return StartCoroutine(BlinkTowards(maxTranseparancy));
            }
        }

        private IEnumerator BlinkTowards(float transparacy) {
            while (Mathf.Abs(canvasGroup.alpha - transparacy) > maxLerpDiffrence) {

                var a = Mathf.Lerp(canvasGroup.alpha, transparacy, lerpSpeed * Time.deltaTime);
                canvasGroup.alpha = a;
                yield return null;
            }
            canvasGroup.alpha = transparacy;
        }

    }
}