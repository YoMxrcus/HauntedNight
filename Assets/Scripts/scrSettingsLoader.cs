using UnityEngine;
using UnityEngine.Audio;

public class scrSettingsLoader : MonoBehaviour
{
    private const string ResolutionPrefKey = "ResolutionIndexPref";

    public AudioMixer mainMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        LoadSettings();
        LoadSavedResolution();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSettings()
    {
        float volumeValue = PlayerPrefs.GetFloat("MasterVolumeValue", 0.75f);

        float volumeInDb = Mathf.Log10(Mathf.Max(volumeValue, 0.0001f)) * 20f;
        mainMixer.SetFloat("MasterVolume", volumeInDb);

        bool isFullscreen = (PlayerPrefs.GetInt("FullscreenPref", 1) == 1);
        Screen.fullScreen = isFullscreen;
    }
    private void LoadSavedResolution()
    {
        if (PlayerPrefs.HasKey(ResolutionPrefKey))
        {
            int savedIndex = PlayerPrefs.GetInt(ResolutionPrefKey);

            if (savedIndex >= 0 && savedIndex < GetComponent<scr>().resolutions.Length)
            {
                Resolution resolutionToApply = GetComponent<scr>().resolutions[savedIndex];
                Screen.SetResolution(resolutionToApply.width,
                                     resolutionToApply.height,
                                     Screen.fullScreen);
            }
            else
            {
                Debug.LogWarning("Saved resolution index was out of bounds, using current system default.");
            }
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width,
                                 Screen.currentResolution.height,
                                 Screen.fullScreen);
        }
    }
}
