using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.GameFlow;

public abstract class GameState : State<GameStateType> {

    [SerializeField]
    protected GameManager manager;

}