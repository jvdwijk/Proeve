using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    private Action OnReset;

    public virtual void TriggerReset(){
        OnReset?.Invoke();
    }
}
