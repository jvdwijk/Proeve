using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Reloads the current active scene
/// </summary>
public class SceneReloader : MonoBehaviour {

    /// <summary>
    /// Reloads the current active scene
    /// </summary>
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}