using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Score {
    public class ScoreHandler : MonoBehaviour {

        private int score = 0;

        public int CurrentScore => score;

        public event Action<int> ScoreChaned;
        public event Action ScoreReset;

        public void AddToScore(int addition) {
            SetScore(score + addition);
        }

        public void ResetScore() {
            SetScore(0);
            ScoreReset?.Invoke();
        }

        public void SetScore(int score) {
            if (this.score == score)
                return;

            this.score = score;
            ScoreChaned?.Invoke(score);
        }

    }
}