using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace PeppaSquad.Settings
{
    
public class VolumeHandler : MonoBehaviour
{
public AudioMixer MusicMixer;
public Slider MusicSlider;
public Slider SfxSlider;
public Toggle MuteToggle;

public void SetLevelMusic(){
    
    MusicMixer.SetFloat("MusicVol", Mathf.Log10(MusicSlider.value)*20);
}
public void SetLevelSFX(){
    
    MusicMixer.SetFloat("SfxVol", Mathf.Log10(SfxSlider.value)*20);
}
public void ToggleMute(){
    if(!MuteToggle.isOn)
    {
    MusicMixer.SetFloat("MasterVol",  Mathf.Log10(0.0001f)*20);
    }
    else
    {
    MusicMixer.ClearFloat("MasterVol");
    }
}

}
}

