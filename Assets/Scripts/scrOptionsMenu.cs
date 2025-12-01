using UnityEngine;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetFloat("VolumePreference", volumeSlider.value);
        PlayerPrefs.SetInt("FullscreenPreference", fullscreenToggle.isOn ? 1 : 0);
    }

    public void LoadSettings()
    {
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference", 0);
        volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference", 1f);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("FullscreenPreference", 1) == 1;
    }
}
