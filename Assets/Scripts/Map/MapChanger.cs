using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanger : Resetter
{
    [SerializeField]
    private GameObject[] maps;
    private GameObject currentMap;
    
    public void ChangeMap(){
        var mapNumber = UnityEngine.Random.Range(0, maps.Length);
        ChangeMap(mapNumber);
    }

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
