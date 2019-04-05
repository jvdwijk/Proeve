using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUnlocker : MonoBehaviour
{
    private const string gameUnlockKey = "Game Unlocked";

    [SerializeField]
    private string sceneName;

    public event Action OnUnlocked;
    
    private void Awake() {
        OnUnlocked += LoadNextScene;
        var unlocked = BoolPlayerPrefs.GetBool(gameUnlockKey);
        
        if (unlocked)
            OnUnlocked?.Invoke();
    }

    public void Unlock(){
        BoolPlayerPrefs.SetBool(gameUnlockKey, true);
        OnUnlocked?.Invoke();
    }

    private void LoadNextScene(){
        //TODO loading screen
        SceneManager.LoadScene(sceneName);
    }

    [ContextMenu("Reset Unlock")]
    private void ResetGameUnlock(){
        BoolPlayerPrefs.SetBool(gameUnlockKey, false);
    }

}
