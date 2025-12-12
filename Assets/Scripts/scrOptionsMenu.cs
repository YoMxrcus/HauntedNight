using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq; // Needed for the Distinct() and ToArray() extension methods
using TMPro; // Use TMPro namespace for TMP_Dropdown

public class scr : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public AudioMixer mixer;
    public string exposedParamName;

    private Resolution[] resolutions; // Made private since we'll filter it

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 1. Get all resolutions from the screen, including duplicates (refresh rates)
        Resolution[] allResolutions = Screen.resolutions;

        // 2. Filter for unique width and height pairs
        // Group resolutions by their (width, height) and take the first one from each group.
        this.resolutions = allResolutions
            .GroupBy(res => new { res.width, res.height })
            .Select(g => g.First())
            .ToArray(); // 

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        int currentResolutionWidth = Screen.currentResolution.width;
        int currentResolutionHeight = Screen.currentResolution.height;

        // 3. Populate options and find the current setting index
        for (int i = 0; i < this.resolutions.Length; i++)
        {
            string option = this.resolutions[i].width + " x " + this.resolutions[i].height;
            options.Add(option);

            // Find the index of the current unique resolution
            if (this.resolutions[i].width == currentResolutionWidth &&
               this.resolutions[i].height == currentResolutionHeight)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        // Set the dropdown to the current resolution
        resolutionDropdown.value = currentResolutionIndex;

        resolutionDropdown.RefreshShownValue();

        // Add Listeners
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // **Full Screen Setup**
        if (fullscreenToggle != null)
        {
            // Load saved fullscreen state, default to true (1) if not saved
            bool isFullscreen = (PlayerPrefs.GetInt("FullscreenPref", 1) == 1);
            fullscreenToggle.isOn = isFullscreen;
            SetFullScreen(isFullscreen); // Apply the initial state
            fullscreenToggle.onValueChanged.AddListener(SetFullScreen); // Add listener for toggle change
        }

        // **Volume Setup**
        float currentVolumeDB;
        // Try to load the saved volume, fall back to AudioMixer default if not set
        float savedSliderValue = PlayerPrefs.GetFloat(exposedParamName + "Value", 1f);

        // Set the slider based on the saved value
        volumeSlider.value = savedSliderValue;

        // Immediately apply the volume to the mixer
        if (mixer.GetFloat(exposedParamName, out currentVolumeDB))
        {
            // The Start() logic for volume initialization was slightly flawed.
            // A better approach is to just apply the stored/default slider value 
            // to the mixer using the existing SetVolume logic.
            SetVolume(savedSliderValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Keep this empty unless you need continuous checks
    }

    public void SetFullScreen(bool isFullScreen)
    {
        // Use the isFullScreen parameter, not the toggle's state
        Screen.fullScreen = isFullScreen;

        // This is a common pattern for toggling, though a simple Screen.fullScreen = isFullScreen
        // is generally sufficient and clearer. 
        // We'll stick to a simpler, universally compatible setting:
        // Screen.fullScreenMode = isFullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed; 

        PlayerPrefs.SetInt("FullscreenPref", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    // ... (SetVolume and SetResolution are largely unchanged, but ensure they use 'this.resolutions')

    public void SetVolume(float sliderValue)
    {
        // Convert the linear slider value (0 to 1) to logarithmic decibels (typically -80dB to 0dB)
        // We use Max() to prevent log(0) which is mathematically undefined (-Infinity)
        float volumeInDb = Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f;

        mixer.SetFloat(exposedParamName, volumeInDb); // 

        PlayerPrefs.SetFloat(exposedParamName + "Value", sliderValue);
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        // Use the filtered array 'this.resolutions'
        Resolution resolution = this.resolutions[resolutionIndex];

        // Set the screen resolution, keeping the current fullscreen state
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionIndexPref", resolutionIndex);
        PlayerPrefs.Save();
    }
}