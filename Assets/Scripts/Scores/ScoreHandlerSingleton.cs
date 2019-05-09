using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Score {
    public class ScoreHandlerSingleton : ScoreHandler {
        private static ScoreHandlerSingleton instance;
        public static ScoreHandlerSingleton Instance => instance;

        private void Awake() {
            if (instance != null) {
                Destroy(this);
                return;
            }

            instance = this;
        }

    }
}