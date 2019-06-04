using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Score;
using TMPro;

namespace PeppaSquad.UI {
    /// <summary>
    /// Handles the highscore UI
    /// </summary>
    public class HighscoreUI : MonoBehaviour {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private HighScoreHandler scoreHandler;

        private void Start() {
            SetScore(scoreHandler.CurrentHighscore);
            scoreHandler.HighscoreChanged += SetScore;
        }

        /// <summary>
        /// Sets the highscore UI
        /// </summary>
        /// <param name="score">the new score</param>
        public void SetScore(int score) {
            scoreText.text = score.ToString();
        }
    }
}