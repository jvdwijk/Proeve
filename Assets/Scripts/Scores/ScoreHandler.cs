using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Score {

    /// <summary>
    /// Handles the player's score
    /// </summary>
    public class ScoreHandler : MonoBehaviour {

        private int score = 0;

        public int CurrentScore => score;

        public event Action<int> HighscoreChanged;
        public event Action ScoreReset;

        public void AddToScore(int addition) {
            SetScore(score + addition);
        }

        /// <summary>
        /// Resets the current score to 0
        /// </summary>
        public void ResetScore() {
            SetScore(0);
            ScoreReset?.Invoke();
        }

        /// <summary>
        /// Changes to current score to a new one
        /// </summary>
        /// <param name="score"></param>
        public void SetScore(int score) {
            if (this.score == score)
                return;

            this.score = score;
            HighscoreChanged?.Invoke(score);
        }

    }
}