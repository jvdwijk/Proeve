using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Score;
using TMPro;

namespace PeppaSquad.UI {

    /// <summary>
    /// Sets the current score in the UI
    /// </summary>
    public class ScoreUI : MonoBehaviour {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private ScoreHandler scoreHandler;

        private void Start() {
            if (scoreHandler == null)
                scoreHandler = ScoreHandlerSingleton.Instance;

            SetScore(scoreHandler.CurrentScore);
            scoreHandler.HighscoreChanged += SetScore;
        }

        /// <summary>
        /// Sets a given score in the score UI
        /// </summary>
        /// <param name="score">The score to best set in the UI</param>
        public void SetScore(int score) {
            scoreText.text = score.ToString();
        }
    }
}