using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LogicaVolumen : MonoBehaviour
{
    public AudioMixer masterMixer;

    public Slider sliderMusica;
    public Slider sliderSfx;

    public float sliderMusicaValue;
    public float sliderSfxValue;

    void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat("MusicVolumen", 0f);
        sliderSfx.value = PlayerPrefs.GetFloat("SfxVolumen", 0f);
        //AudioListener.volume = sliderMusicaValue;
        //AudioListener.volume = sliderSfxValue;
    }

    public void ChangeSliderMusic(float valorMusic)
    {
        sliderMusicaValue = valorMusic;
        PlayerPrefs.SetFloat("MusicVolumen", sliderMusicaValue);
        masterMixer.SetFloat("MusicVolumen", sliderMusicaValue);
        //AudioListener.volume = sliderMusica.value;

        masterMixer.SetFloat("MusicVolumen", valorMusic);
    }

    public void ChangeSliderSfx(float valorSfx)
    {
        sliderSfxValue = valorSfx;

        PlayerPrefs.SetFloat("SfxVolumen", sliderSfxValue);
        masterMixer.SetFloat("SfxVolumen", sliderSfxValue);
        masterMixer.SetFloat("SfxVolumen", valorSfx);
    }

}
