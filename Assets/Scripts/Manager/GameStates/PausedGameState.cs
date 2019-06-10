using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.GameFlow;

public abstract class PausedGameState : GameState {

    public override void EnterState() {
        if (!manager.GameRunning || manager.GamePaused)
            return;

        manager.PauseGame(true);
    }

    public override void LeaveState() {
        if (!manager.GamePaused)
            return;

        manager.PauseGame(false);
    }

}