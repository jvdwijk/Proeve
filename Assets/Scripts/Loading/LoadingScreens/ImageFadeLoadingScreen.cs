using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PeppaSquad.Loading.LoadingScreens
{
    public class ImageFadeLoadingScreen : LoadingScreenUI
    {

        [SerializeField]
        private Image image;

        [SerializeField, Tooltip("Fade time in seconds")]
        private float fadeTime;

        [SerializeField, Tooltip("Scale fadeTime to the diff")]
        private bool scaleFadeTime;

        private Coroutine imageFadeRoutine;

        public override void Activate(Action OnLoadingscreenActive = null)
        {
            image.gameObject.SetActive(true);
            StartFadeRoutine(1, OnLoadingscreenActive);
        }

        public override void Deactivate()
        {
            Action deactivateImage = () => image.gameObject.SetActive(false);
            StartFadeRoutine(0, deactivateImage);
        }

        private void SetImageAlpha(float alpha){
            var color = image.color;
            color.a = alpha;
            image.color = color;
        }

        private void StartFadeRoutine(float fadeValue, Action onFinishedFade = null){
            if (imageFadeRoutine != null)
                StopCoroutine(imageFadeRoutine);

            imageFadeRoutine = StartCoroutine(FadeImageTo(fadeValue, onFinishedFade));
        }

        private IEnumerator FadeImageTo(float fadeValue, Action onFinishedFade = null){
            fadeValue = Mathf.Clamp01(fadeValue);
            var diff = fadeValue - image.color.a;
            var absoluteDiff = Mathf.Abs(diff);
            var scaledFadeTime = scaleFadeTime ? fadeTime * absoluteDiff : fadeTime;
            var step = diff / scaledFadeTime;
            while (absoluteDiff > 0)
            {
                var timeScaledStep = step * Time.deltaTime;
                absoluteDiff -= Mathf.Abs(timeScaledStep);
                SetImageAlpha(image.color.a + timeScaledStep);
                yield return null;
            }
            SetImageAlpha(fadeValue);
            onFinishedFade?.Invoke();
        }

    }
}
