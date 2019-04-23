using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.DataSaving {

    /// <summary>
    /// Object which can save data.
    /// </summary>
    public interface IDataSaver {
        bool IsDirty { get; }

        event Action OnSetDirty;

        void Save();
        bool Load();
    }
}