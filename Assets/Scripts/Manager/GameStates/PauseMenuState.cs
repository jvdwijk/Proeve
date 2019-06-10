using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuState : PausedGameState {

    [SerializeField]
    private GameObject pauseMenu;

    public override GameStateType StateName => GameStateType.PauseMenu;

    public override void EnterState() {
        base.EnterState();
        pauseMenu.SetActive(true);
    }

    public override void LeaveState() {
        base.LeaveState();
        pauseMenu.SetActive(false);
    }

    public void Continue() {
        StateMachine.SetState(GameStateType.Scanning);
    }

    public void ToMainManu() {
        manager.ResetGame();
        StateMachine.SetState(GameStateType.MainMenu);
    }

}