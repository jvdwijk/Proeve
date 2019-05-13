using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Score;
using TMPro;

namespace PeppaSquad.UI {
    public class HighscoreUI : MonoBehaviour {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private HighScoreHandler scoreHandler;

        private void Start() {
            SetScore(scoreHandler.CurrentHighscore);
            scoreHandler.HighscoreChanged += SetScore;
        }

        public void SetScore(int score) {
            scoreText.text = score.ToString();
        }
    }
}