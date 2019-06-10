using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreState : PausedGameState {

    [SerializeField]
    private GameObject storeUI;

    public override GameStateType StateName => GameStateType.Store;

    public override void EnterState() {
        base.EnterState();
        storeUI.SetActive(true);
    }

    public override void LeaveState() {
        base.LeaveState();
        storeUI.SetActive(false);
    }

    public void Back() {
        if (manager.GameRunning) {
            StateMachine.SetState(GameStateType.Scanning);
        } else {
            StateMachine.SetState(GameStateType.MainMenu);
        }
    }

}