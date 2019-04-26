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
            timer.TimerUpdated += UpdateTimer;
            timer.TimerReset += () => StartCoroutine(LerpToCurrent());
        }

        public void UpdateTimer(float newTime) {
            var current = newTime / timer.StartTime;
            timerBar.fillAmount = current;
        }

        private IEnumerator LerpToCurrent() {
            timer.TimerUpdated -= UpdateTimer;
            while (timerBar.fillAmount - (timer.CurrentTime / timer.StartTime) < 0.01f) {
                var current = timer.CurrentTime / timer.StartTime;
                timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, current, lerpSpeed * Time.deltaTime);
                yield return null;
            }
            timer.TimerUpdated += UpdateTimer;
        }
    }
}