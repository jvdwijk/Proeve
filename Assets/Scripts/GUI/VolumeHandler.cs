using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace PeppaSquad.GUI
{
    
public class VolumeHandler : MonoBehaviour
{
[SerializeField] private AudioMixer musicMixer;
[SerializeField] private Slider musicSlider;
[SerializeField] private Slider SfxSlider;
[SerializeField] private Toggle muteToggle;
private const string musicVol = "MusicVol";
private const string sfxVol = "SfxVol";
private const string masterVol = "MasterVol";

        /// <summary>
        /// Updates the music volume when the player changes its value on a slider
        /// </summary>

public void SetLevelMusic(){
    
    musicMixer.SetFloat(musicVol, Mathf.Log10(musicSlider.value)*20);
}

        /// <summary>
        /// Updates the sfx volume when the player changes its value on a slider
        /// </summary>
public void SetLevelSFX(){
    
    musicMixer.SetFloat(sfxVol, Mathf.Log10(SfxSlider.value)*20);
}

/// <summary>
        /// Toggles the music on and off when the player ticks a checkbox.
        /// </summary>
public void ToggleMute(){
    if(!muteToggle.isOn)
    {
    musicMixer.SetFloat(masterVol,  Mathf.Log10(0.0001f)*20);
    }
    else
    {
    musicMixer.ClearFloat(masterVol);
    }
}


}
}

