using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState {

    [SerializeField]
    private GameObject gameUI;

    public override GameStateType StateName => GameStateType.Playing;

    public override void EnterState() {
        gameUI.SetActive(true);
        manager.OnMarkerTrakedChanged += HandleTrackingState;

        if (!manager.GameRunning)
            manager.StartGame();
    }

    public override void LeaveState() {
        gameUI.SetActive(false);
        manager.OnMarkerTrakedChanged -= HandleTrackingState;
    }

    public void OpenPauseMenu() {
        StateMachine.SetState(GameStateType.PauseMenu);
    }

    public void OpenStore() {
        StateMachine.SetState(GameStateType.Store);
    }

    public void GameOver() {
        manager.ResetGame();
        StateMachine.SetState(GameStateType.GameOver);
    }

    private void HandleTrackingState(bool trackState) {
        if (trackState)
            return;

        StateMachine.SetState(GameStateType.Scanning);
    }

}