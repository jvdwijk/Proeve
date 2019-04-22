using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataSaver {
    bool IsDirty { get; }

    event Action OnSetDirty;

    void Save();
    bool Load();
}