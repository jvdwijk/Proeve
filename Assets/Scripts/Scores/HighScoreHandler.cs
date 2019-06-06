using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Score {
    /// <summary>
    /// Checks if a new hiscore has been reached and saves it to the playerstats.
    /// </summary>
    public class HighScoreHandler : MonoBehaviour {
        [SerializeField]
        private PlayerStatsHandler playerStats;

        [SerializeField]
        private ScoreHandler scoreHandler;

        private Stat<PlayerStatType> highscoreStat;

        /// <summary>
        /// The current highscore
        /// </summary>
        /// <value></value>
        public int CurrentHighscore { get; private set; } = 0;

        /// <summary>
        /// Called when a new highscore is reached
        /// </summary>
        public event Action<int> HighscoreChanged;

        private void Start() {

            highscoreStat = playerStats.GetOrCreateStat(PlayerStatType.Highscore);
            SetHighScore((int) highscoreStat.Value);

            CheckScore();
            scoreHandler.HighscoreChanged += (score) => CheckScore();
        }

        /// <summary>
        /// checks if a new highscore has been reached
        /// </summary>
        public void CheckScore() {
            if (scoreHandler.CurrentScore <= CurrentHighscore)
                return;

            SetHighScore(scoreHandler.CurrentScore);
        }

        /// <summary>
        /// Changes the current highscore with a new one.
        /// </summary>
        /// <param name="score"></param>
        private void SetHighScore(int score) {
            CurrentHighscore = score;
            highscoreStat.SetValue(score);
            HighscoreChanged?.Invoke(score);
        }

    }
}