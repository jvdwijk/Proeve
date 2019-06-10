using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningState : PausedGameState {

    [SerializeField]
    private GameObject scanUI;

    private bool hasScanned = false;

    public override GameStateType StateName => GameStateType.Scanning;

    public override void EnterState() {
        if (manager.MarkerTracked) {
            OnMarkerTracked();
            return;
        }
        base.EnterState();
        manager.OnMarkerTrakedChanged += CheckMarkerTrackedState;
        scanUI.SetActive(true);
        hasScanned = true;
    }

    public override void LeaveState() {
        if (!hasScanned)
            return;

        base.LeaveState();
        manager.OnMarkerTrakedChanged -= CheckMarkerTrackedState;
        scanUI.SetActive(false);
        hasScanned = false;
    }

    private void CheckMarkerTrackedState(bool markerTrackedState) {
        if (markerTrackedState)
            OnMarkerTracked();
    }

    private void OnMarkerTracked() {
        StateMachine.SetState(GameStateType.Playing);
    }
}