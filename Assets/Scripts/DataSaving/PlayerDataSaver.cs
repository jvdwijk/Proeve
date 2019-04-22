using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats.PlayerStats;

public class PlayerDataSaver : MonoBehaviour, IDataSaver {

    [SerializeField]
    private PlayerStatsHandler PlayerStats;

    private ObjectSaver saver;

    private bool isDirty = false;

    public bool IsDirty => IsDirty;

    public event Action OnSetDirty;

    public bool Load() {
        throw new System.NotImplementedException();
    }

    public void Save() {
        throw new System.NotImplementedException();
    }
}