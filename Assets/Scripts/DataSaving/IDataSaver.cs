using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.DataSaving {

    /// <summary>
    /// Object which can save and load data.
    /// </summary>
    public interface IDataSaver {
        /// <summary>
        /// Is there something to be saved.
        /// </summary>
        /// <value></value>
        bool IsDirty { get; }

        /// <summary>
        /// called when an object is set to Dirty
        /// </summary>
        event Action OnSetDirty;

        /// <summary>
        /// Saves data
        /// </summary>
        void Save();

        /// <summary>
        /// Loads data
        /// </summary>
        /// <returns></returns>
        bool Load();
    }
}