using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PeppaSquad.Utils {
    public class Timer : MonoBehaviour {

        [SerializeField]
        private float startTime = 10;

        public float StartTime => startTime;
        public float CurrentTime { get; private set; }
        public bool Paused { get; set; }

        public event Action TimerStarted;
        public event Action<float> TimerUpdated;
        public UnityEvent TimerEnded;

        private Coroutine countdownRoutine;

        private void Awake() {
            StartTimer();
        }

        public Coroutine StartTimer() {
            if (countdownRoutine != null)
                return null;

            CurrentTime = startTime;
            countdownRoutine = StartCoroutine(CountDown());
            return countdownRoutine;
        }

        public void StopTimer() {
            if (countdownRoutine == null)
                return;

            StopCoroutine(countdownRoutine);
        }

        public void SetStartTime(float startTime) {
            this.startTime = startTime;
        }

        public void ResetTimer() {
            CurrentTime = startTime;
        }

        public void AddTime(float amount) {
            ChangeCurrentTime(CurrentTime + amount);
        }

        private IEnumerator CountDown() {
            TimerStarted?.Invoke();
            while (CurrentTime > 0) {
                yield return null;
                var countdownAmount = Paused ? 0 : Time.deltaTime;
                AddTime(-countdownAmount);
            }
            CurrentTime = 0;
            TimerEnded?.Invoke();
        }

        private void ChangeCurrentTime(float newTime) {

            newTime = newTime < 0 ? 0 : newTime;
            if (newTime == CurrentTime)
                return;

            CurrentTime = newTime;
            TimerUpdated?.Invoke(CurrentTime);

        }
    }
}