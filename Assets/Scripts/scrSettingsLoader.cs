using UnityEngine;
using UnityEngine.Audio;

public class scrSettingsLoader : MonoBehaviour
{
    // Removed ResolutionPrefKey as this script no longer loads resolution

    public AudioMixer mainMixer;

    // Awake is called once before the first execution of Start
    void Awake()
    {
        // Only load mixer and fullscreen state here
        LoadSettings();

        // Removed LoadSavedResolution() as it will be handled by scr
    }

    public void LoadSettings()
    {
        // **Volume Loading**
        // The exposed parameter name for the volume must match the one in the AudioMixer.
        // I'm guessing the exposed parameter name in the AudioMixer is "MasterVolume"
        // and the PlayerPref key for the slider value is "MasterVolumeValue" (matching the default below).
        float volumeValue = PlayerPrefs.GetFloat("MasterVolumeValue", 0.75f);

        // Convert linear slider value (0.0001 to 1.0) to logarithmic dB (-80dB to 0dB)
        float volumeInDb = Mathf.Log10(Mathf.Max(volumeValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("MasterVolume", volumeInDb); // 

        // **Fullscreen Loading**
        bool isFullscreen = (PlayerPrefs.GetInt("FullscreenPref", 1) == 1);
        Screen.fullScreen = isFullscreen;
    }
}