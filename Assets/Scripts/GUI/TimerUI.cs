using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PeppaSquad.Utils;

namespace PeppaSquad.UI {

    public class TimerUI : MonoBehaviour {
        [SerializeField]
        private Timer timer;

        [SerializeField]
        private Image timerBar;

        [SerializeField]
        private float lerpSpeed;

        private void Awake() {
            lerpSpeed = lerpSpeed <= 0 ? 1 : lerpSpeed;
            timer.TimerReset += () => StartCoroutine(LerpToCurrent());
        }

        private void OnEnable() {
            timer.TimerUpdated += UpdateTimer;
        }

        private void OnDisable() {
            timer.TimerUpdated -= UpdateTimer;
            UpdateTimer(timer.CurrentTime);
        }

        /// <summary>
        /// Updates the timer bar.
        /// </summary>
        /// <param name="newTime">Time to which the UI will be updated</param>
        public void UpdateTimer(float newTime) {
            var current = newTime / timer.StartTime;
            timerBar.fillAmount = current;
        }

        /// <summary>
        /// Lerps to the current time on the timer.
        /// </summary>
        /// <returns></returns>
        private IEnumerator LerpToCurrent() {
            timer.TimerUpdated -= UpdateTimer;
            while (timerBar.fillAmount - (timer.CurrentTime / timer.StartTime) < 0.01f) {
                var current = timer.CurrentTime / timer.StartTime;
                timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, current, lerpSpeed * Time.deltaTime);
                yield return null;
            }
            timerBar.fillAmount = timer.CurrentTime / timer.StartTime;
            timer.TimerUpdated += UpdateTimer;
        }
    }
}