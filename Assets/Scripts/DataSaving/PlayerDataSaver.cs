using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;

public class PlayerDataSaver : MonoBehaviour, IDataSaver {

    [SerializeField]
    private PlayerStatsHandler playerStats;

    [SerializeField]
    private string appdataSubDirectory = @"\GameSaves";

    [SerializeField]
    private string fileName = "data.dat";

    private ObjectSaver saver;
    private bool isDirty = false;

    public bool IsDirty => IsDirty;

    public event Action OnSetDirty;

    private void Awake() {
        saver = new ObjectSaver(GetPath());
        HandleSetDirty();
        Load();
    }

    public void Save() {
        var stats = new Dictionary<PlayerStatType, float>();
        var playerStatTypes = Enum.GetValues(typeof(PlayerStatType));
        foreach (PlayerStatType statType in playerStatTypes) {
            var stat = playerStats.GetStat(statType);

            if (stat == null)
                continue;

            stats.Add(stat.StatType, stat.Value);
        }
        saver.SaveObject(fileName, stats);
    }

    public bool Load() {
        Dictionary<PlayerStatType, float> stats;
        LoadResult result = saver.LoadObject(fileName, out stats);

        if (result != LoadResult.Succes)
            return false;

        foreach (var savedStat in stats) {
            var stat = playerStats.GetOrCreateStat(savedStat.Key);
            stat.Value = savedStat.Value;
        }
        return true;

    }

    private void OnApplicationQuit() {
        if (isDirty)
            Save();
    }

    private string GetPath() {
        return Path.Combine(Application.persistentDataPath, appdataSubDirectory);
    }

    private void HandleSetDirty() {
        var playerStatTypes = Enum.GetValues(typeof(PlayerStatType));
        foreach (PlayerStatType statType in playerStatTypes) {
            var stat = playerStats.GetStat(statType);

            if (stat == null)
                continue;

            stat.StatChanged += (changedStat) => {
                if (isDirty)
                    return;

                isDirty = true;
                OnSetDirty?.Invoke();
            };
        }
        playerStats.StatCreated += AddStat;
    }

    private void AddStat(Stat<PlayerStatType> newStat) {
        newStat.StatChanged += (changedStat) => isDirty = true;
    }
}