using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicClip : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    public void SetMusicAudioClip(AudioClip audio){

        musicAudioSource.clip = audio;
        musicAudioSource.Play();

    }
}
