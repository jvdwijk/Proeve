using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups;

public class MapChanger : Resetter {
    
    [SerializeField]
    private PickupUI pickupUI;
    [SerializeField]
    private GameObject[] maps;
    private GameObject currentMap;

    private PickupsHandler pickupHandler;

    /// <summary>
    /// Randomizes what map the game uses.
    /// </summary>
    public void ChangeMap() {
        int mapNumber = UnityEngine.Random.Range(0, maps.Length);
        maps[mapNumber].SetActive(true);

        pickupHandler?.RemovePickUps();

        currentMap?.SetActive(false);
        maps[mapNumber].SetActive(true);
        currentMap = maps[mapNumber];

        pickupHandler = currentMap.GetComponentInChildren<PickupsHandler>();
        pickupHandler?.StartSpawningPickups();
        pickupUI.OnMapChange(pickupHandler);
    }

    public override void TriggerReset() {
        currentMap.SetActive(false);
        currentMap = null;
        base.TriggerReset();
    }
}