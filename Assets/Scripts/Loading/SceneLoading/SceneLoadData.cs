using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Loading;

namespace PeppaSquad.SceneLoading
{
    public class SceneLoadData : LoadData
    {
        private const float loadPoint = 0.9f;

        public bool ChangeSceneOnReady
        {
            get { return operation.allowSceneActivation; }
            set { operation.allowSceneActivation = value; }
        }

        public AsyncOperation Operation => operation;

        private AsyncOperation operation;

        public SceneLoadData(AsyncOperation operation){
            this.operation = operation;
        }

        protected override float GetProgress() {
            return operation.progress / loadPoint;
        }

        protected override bool IsReadyCheck() {
            return operation.progress == loadPoint;
        }
    }
}
