using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupInput : MonoBehaviour {

    public event Action OnClicked;

    private void OnMouseDown() {
        OnClicked?.Invoke();
    }

}