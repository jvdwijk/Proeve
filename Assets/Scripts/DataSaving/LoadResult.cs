using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.DataSaving {
    /// <summary>
    /// Possible loading results
    /// </summary>
    public enum LoadResult {
        Succes,
        WrongType,
        FileDoesNotExist,
    }
}