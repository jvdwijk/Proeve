using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PeppaSquad.Loading.LoadingScreens;

namespace PeppaSquad.SceneLoading
{
    public class SceneChangeHandler : MonoBehaviour
    {

        private static SceneChangeHandler instance;
        public static SceneChangeHandler Instance => instance;

        [SerializeField]
        private LoadingScreenUI loadingUI;

        private void Awake() {

            transform.parent = null;
            DontDestroyOnLoad(this);

            if (instance != null){
                Destroy(this);
                return;
            }
            
            instance = this;
        }

        /// <summary>
        /// Loads and activates a scene.
        /// </summary>
        /// <param name="sceneName">name of the scene</param>
        public void ChangeScene(string sceneName) {
            loadingUI.Activate(() => {
                SceneLoadData loadData = StartLoading(sceneName);
                loadingUI.SetLoadingData(loadData);
                loadData.Operation.completed += (e) => loadingUI.Deactivate();
            });
        }

        private SceneLoadData StartLoading(string sceneName)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            op.allowSceneActivation = true;
            return new SceneLoadData(op);
        }

        private void ActivateSceneChangeOnReady(SceneLoadData loadData){
            loadData.ChangeSceneOnReady = true;
        }
    }

}

