using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEffectSpawner : MonoBehaviour {

    [SerializeField]
    private BoostEffect[] boosts;

    public BoostEffect SpawnRandomBoost() {
        int boostIndex = Random.Range(0, boosts.Length);
        BoostEffect prefab = boosts[boostIndex];

        BoostEffect boost = Instantiate(prefab);
        boost.transform.parent = transform;

        return boost;
    }

}