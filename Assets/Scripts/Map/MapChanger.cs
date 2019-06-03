using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanger : Resetter
{
    [SerializeField]
    private GameObject[] maps;
    private GameObject currentMap;
    
    /// <summary>
    /// Randomizes what map the game uses.
    /// </summary>
    public void ChangeMap(){
        var mapNumber = UnityEngine.Random.Range(0, maps.Length);
        ChangeMap(mapNumber);
    }

    /// <summary>
    /// Enable the given map and turn the old one off.
    /// </summary>
    /// <param name="mapNumber">The map that gets turned on.</param>
    public void ChangeMap(int mapNumber){
        maps[mapNumber].SetActive(true);
        currentMap?.SetActive(false);
        currentMap = maps[mapNumber];
    }

    public override void TriggerReset(){
        currentMap.SetActive(false);
        currentMap = null;
        base.TriggerReset();
    }
}
