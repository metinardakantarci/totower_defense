using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Ayarlar : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown dropdown;

    public AudioMixer mixer;
    public Slider slider;
    private void Start() {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();

        List<string> ayarlar = new List<string>();
        int seciliCozunurlukIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string ayar = resolutions[i].width + "x" + resolutions[i].height;
            ayarlar.Add(ayar);

            if(resolutions[i].width == Screen.currentResolution.width &&
              resolutions[i].height == Screen.currentResolution.height )
            {
                seciliCozunurlukIndex = i;
                dropdown.value = seciliCozunurlukIndex;
                dropdown.RefreshShownValue();
            }
        }

        dropdown.AddOptions(ayarlar);
    }

    public void SesAyarla()
    {
        float ses = slider.value;
        mixer.SetFloat("master", ses);
    }
    public void CozunurlukAyarla(int cozunurlukIndex)
    {
        Resolution resolution = resolutions[cozunurlukIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void GrafikAyarlari(int grafikIndex)
    {
        QualitySettings.SetQualityLevel(grafikIndex);
    }

    public void TamEkran(bool tamEkranMi)
    {
        Screen.fullScreen = tamEkranMi;
    }
}
