using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
public class ImageScanner : MonoBehaviour
{

    [SerializeField]
    private ImageTargetBehaviour imageTarget;

    public UnityEvent OnImageTracked;

    private void Awake() {
        StartCoroutine(WaitForImageTracked());
    }

    private IEnumerator WaitForImageTracked(){
        while(imageTarget.CurrentStatus != TrackableBehaviour.Status.TRACKED){
            yield return null;
        }
        
        OnImageTracked.Invoke();
    }


}
