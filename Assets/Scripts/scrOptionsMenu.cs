using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class scr : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown; public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public AudioMixer mixer;
    public string exposedParamName;

    public Resolution[] resolutions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentResolutionIndex;

        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        bool isFullscreen = (PlayerPrefs.GetInt("FullscreenPref", 1) == 1);

        Screen.fullScreen = isFullscreen;

        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = Screen.fullScreen;
        }

        float currentVolume;
        if (mixer.GetFloat(exposedParamName, out currentVolume))
        {
            volumeSlider.value = Mathf.Pow(10f, currentVolume / 20f);
        }

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        PlayerPrefs.SetInt("FullscreenPref", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SetVolume(float sliderValue)
    {
        float volumeInDb = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;

        mixer.SetFloat(exposedParamName, volumeInDb);

        PlayerPrefs.SetFloat(exposedParamName + "Value", sliderValue);
        PlayerPrefs.Save();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionIndexPref", resolutionIndex);
        PlayerPrefs.Save();
    }
}
