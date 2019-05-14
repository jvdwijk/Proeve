using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Score {
    public class HighScoreHandler : MonoBehaviour {
        [SerializeField]
        private PlayerStatsHandler playerStats;

        [SerializeField]
        private ScoreHandler scoreHandler;

        private Stat<PlayerStatType> highscoreStat;

        public int CurrentHighscore { get; private set; } = 0;

        public event Action<int> HighscoreChanged;

        private void Start() {

            highscoreStat = playerStats.GetOrCreateStat(PlayerStatType.Highscore);
            SetHighScore((int) highscoreStat.Value);

            CheckScore();
            scoreHandler.HighscoreChanged += (score) => CheckScore();
        }

        public void CheckScore() {
            if (scoreHandler.CurrentScore <= CurrentHighscore)
                return;

            SetHighScore(scoreHandler.CurrentScore);
        }

        private void SetHighScore(int score) {
            CurrentHighscore = score;
            highscoreStat.SetValue(score);
            HighscoreChanged?.Invoke(score);
        }

    }
}