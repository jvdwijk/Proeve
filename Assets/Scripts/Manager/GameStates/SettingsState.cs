using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsState : GameState
{
    [SerializeField]
    private GameObject settingsMenu;

    public override GameStateType StateName => GameStateType.Settings;

    public override void EnterState() {
        base.EnterState();
        settingsMenu.SetActive(true);
    }

    public override void LeaveState() {
        base.LeaveState();
        settingsMenu.SetActive(false);
    }

    public void ToMainManu() {
        StateMachine.SetState(GameStateType.MainMenu);
    }

    public void ToSettings() {
        StateMachine.SetState(GameStateType.Settings);
    }
}
