using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider generalVolumeSlider;
    [SerializeField] private Slider interfaceVolumeSlider;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;

    private float musicVolume = 1.0f;
    private float generalVolume = 1.0f;
    private float interfaceVolume = 1.0f;

    private Resolution[] resolutions;

    private void Start()
{
    // Initialise les sliders de volume
    if (musicVolumeSlider == null)
    {
        Debug.LogError("Music Volume Slider is not assigned!");
    }
    else
    {
        musicVolumeSlider.value = musicVolume;
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    if (generalVolumeSlider == null)
    {
        Debug.LogError("General Volume Slider is not assigned!");
    }
    else
    {
        generalVolumeSlider.value = generalVolume;
        generalVolumeSlider.onValueChanged.AddListener(SetGeneralVolume);
    }

    if (interfaceVolumeSlider == null)
    {
        Debug.LogError("Interface Volume Slider is not assigned!");
    }
    else
    {
        interfaceVolumeSlider.value = interfaceVolume;
        interfaceVolumeSlider.onValueChanged.AddListener(SetInterfaceVolume);
    }

    if (resolutionDropdown == null)
    {
        Debug.LogError("Resolution Dropdown is not assigned!");
    }
    else
    {
        // Initialiser les options de résolution
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
    }

    if (fullscreenToggle == null)
    {
        Debug.LogError("Fullscreen Toggle is not assigned!");
    }
    else
    {
        // Initialiser le toggle du mode plein écran
        fullscreenToggle.isOn = Screen.fullScreen;
        fullscreenToggle.onValueChanged.AddListener(SetFullScreen);
    }
}

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        // Appliquer le volume à la musique (ajuster selon votre système audio)
        // Example: AudioManager.Instance.SetMusicVolume(volume);
    }

    public void SetGeneralVolume(float volume)
    {
        generalVolume = volume;
        AudioListener.volume = volume;
    }

    public void SetInterfaceVolume(float volume)
    {
        interfaceVolume = volume;
        // Appliquer le volume à l'interface (ajuster selon votre système audio)
        // Example: AudioManager.Instance.SetInterfaceVolume(volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
