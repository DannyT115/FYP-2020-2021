using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions(); // Clear list of resolutions initially.

        List<string> options = new List<string>(); 

        int currentResolutionIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++) // Loop through resolutions, format to strings, add them to options list.
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; 
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && // Check the current resolution of the users system,
                resolutions[i].height == Screen.currentResolution.height) // and default to that setting in the options menu on start.
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Method for changing volume in menu using slider.
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetMusicVolume (float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    // Method for changing the Graphics quality preset via dropdown menu.
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Method for changing to fullscreen mode using toggle in menu
    // TODO: This might change to a dropdown to include Windowed and Borderless mode.
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
