using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PeppaSquad.Utils {
    public class Timer : MonoBehaviour {

        [SerializeField]
        private float startTime = 10;

        /// <summary>
        /// The timers default start time
        /// </summary>
        public float StartTime => startTime;
        /// <summary>
        /// The timers current time left
        /// </summary>
        /// <value></value>
        public float CurrentTime { get; private set; }
        /// <summary>
        /// If the timer is paused
        /// </summary>
        /// <value></value>
        public bool Paused { get; set; }

        /// <summary>
        /// Called when the timer is started
        /// </summary>
        public event Action TimerStarted;
        /// <summary>
        /// Called when a new current time is set
        /// </summary>
        public event Action<float> TimerUpdated;
        /// <summary>
        /// Called when the timer is stopped
        /// </summary>
        public event Action TimerStopped;
        /// <summary>
        /// Called when the timer is reset
        /// </summary>
        public event Action TimerReset;
        /// <summary>
        /// Called when the timers ends
        /// </summary>
        public UnityEvent TimerEnded;

        private Coroutine countdownRoutine;
        private bool isRunning;

        /// <summary>
        /// Stars the timer
        /// </summary>
        /// <returns>The timers coroutine</returns>
        public Coroutine StartTimer() {
            if (isRunning)
                return countdownRoutine;

            isRunning = true;
            CurrentTime = startTime;
            countdownRoutine = StartCoroutine(CountDown());
            return countdownRoutine;
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void StopTimer() {
            if (!isRunning)
                return;

            isRunning = false;
            StopCoroutine(countdownRoutine);
            TimerStopped?.Invoke();
        }

        /// <summary>
        /// Sets a new default start time for the timer
        /// </summary>
        /// <param name="startTime">the new starttime</param>
        public void SetStartTime(float startTime) {
            this.startTime = startTime;
        }

        /// <summary>
        /// Resets the timer to it's start time
        /// </summary>
        public void ResetTimer() {
            CurrentTime = startTime;
            TimerReset?.Invoke();
        }

        /// <summary>
        /// Adds time to timers current time left
        /// </summary>
        /// <param name="amount"></param>
        public void AddTime(float amount) {
            ChangeCurrentTime(CurrentTime + amount);
        }

        /// <summary>
        /// the countdown routine
        /// </summary>
        /// <returns></returns>
        private IEnumerator CountDown() {
            TimerStarted?.Invoke();
            while (CurrentTime > 0) {
                yield return null;
                var countdownAmount = Paused ? 0 : Time.deltaTime;
                AddTime(-countdownAmount);
            }
            CurrentTime = 0;
            isRunning = false;
            TimerEnded?.Invoke();
        }

        /// <summary>
        /// changes the current time
        /// </summary>
        /// <param name="newTime">the new current time</param>
        private void ChangeCurrentTime(float newTime) {

            newTime = newTime < 0 ? 0 : newTime;
            if (newTime == CurrentTime)
                return;

            CurrentTime = newTime;
            TimerUpdated?.Invoke(CurrentTime);

        }
    }
}