using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCriticalPointSpawner : MonoBehaviour {

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 size;
    [SerializeField]
    private Quaternion rotation;

    [SerializeField]
    private bool drawGizmos;

    private void OnDrawGizmos() {

        if (!drawGizmos)
            return;

        Gizmos.DrawWireCube(transform.position + offset, size);
    }

}