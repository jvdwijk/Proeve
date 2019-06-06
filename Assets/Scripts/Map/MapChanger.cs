using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups;

public class MapChanger : Resetter {
    [SerializeField]
    private GameObject[] maps;
    private GameObject currentMap;

    /// <summary>
    /// Randomizes what map the game uses.
    /// </summary>
    public void ChangeMap() {
        var mapNumber = UnityEngine.Random.Range(0, maps.Length);
        maps[mapNumber].SetActive(true);
        currentMap?.SetActive(false);
        currentMap = maps[mapNumber];
        currentMap.GetComponentInChildren<PickupsHandler>().StartSpawningPickups();
    }

    public override void TriggerReset() {
        currentMap.SetActive(false);
        currentMap = null;
        base.TriggerReset();
    }
}