using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable {
    bool IsDirty { get; }

    event Action OnSetDirty;

    void OnSave();
}