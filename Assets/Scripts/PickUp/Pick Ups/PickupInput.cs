using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupInput : MonoBehaviour {

    [SerializeField]
    private UnityEvent OnPickedUp;

    private void OnMouseDown() {
        OnPickedUp.Invoke();
    }

}