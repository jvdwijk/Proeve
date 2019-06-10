using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameState {

    [SerializeField]
    private GameObject mainMenuUI;

    public override GameStateType StateName => GameStateType.MainMenu;

    public override void EnterState() {
        mainMenuUI.SetActive(true);
    }

    public override void LeaveState() {
        mainMenuUI.SetActive(false);
    }

    public void StartGame() {
        StateMachine.SetState(GameStateType.Scanning);
    }

    public void OpenStore() {
        StateMachine.SetState(GameStateType.Store);
    }

}