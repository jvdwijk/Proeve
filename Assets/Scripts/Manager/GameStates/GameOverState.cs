using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState {

    [SerializeField]
    private GameObject gameOverUI;

    public override GameStateType StateName => GameStateType.GameOver;

    public override void EnterState() {
        gameOverUI.SetActive(true);
    }

    public override void LeaveState() {
        gameOverUI.SetActive(false);
    }

    public void Retry() {
        StateMachine.SetState(GameStateType.Scanning);
    }

    public void ToMainManu() {
        StateMachine.SetState(GameStateType.MainMenu);
    }

}