using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Score;
using TMPro;

namespace PeppaSquad.UI {
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

        public void SetScore(int score) {
            scoreText.text = score.ToString();
        }
    }
}