using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SettingsSystem : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private SettingsData _settings;

    private readonly List<Resolution> _resolutions = new List<Resolution>();
    
    private void Awake()
    {
        G.Instance.SaveSystem.LoadGame();
        _settings = G.Instance.SaveSystem.Data.settings;

        LoadResolutions();
        ApplySettings();
        LoadUI();
    }
    
    public void OnSettingsButtonPressed()
    {
        settingsMenu.SetActive(true);
    }
    
    public void SetMasterVolume(float value)
    {
        _settings.masterVolume = value;
        ApplyVolume("Master", value);
    }

    public void SetMusicVolume(float value)
    {
        _settings.musicVolume = value;
        ApplyVolume("Music", value);
    }

    public void SetSfxVolume(float value)
    {
        _settings.sfxVolume = value;
        ApplyVolume("SFX", value);
    }

    public void SetFullscreen(bool value)
    {
        _settings.fullscreen = value;
        Screen.fullScreen = value;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = _resolutions[index];

        _settings.resolutionWidth = resolution.width;
        _settings.resolutionHeight = resolution.height;

        Screen.SetResolution(
            resolution.width,
            resolution.height,
            _settings.fullscreen
        );
    }

    public void SaveAndExit()
    {
        G.Instance.SaveSystem.SaveGame();
        settingsMenu.SetActive(false);
    }

    private void ApplySettings()
    {
        ApplyVolume("Master", _settings.masterVolume);
        ApplyVolume("Music", _settings.musicVolume);
        ApplyVolume("SFX", _settings.sfxVolume);

        Screen.fullScreen = _settings.fullscreen;

        if (_resolutions.Count > 0)
        {
            Resolution resolution = _resolutions.Find(r =>
                r.width == _settings.resolutionWidth &&
                r.height == _settings.resolutionHeight
            );

            if (resolution.width != 0)
            {
                Screen.SetResolution(
                    resolution.width,
                    resolution.height,
                    _settings.fullscreen
                );
            }
            else
            {
                Screen.SetResolution(
                    Screen.currentResolution.width,
                    Screen.currentResolution.height,
                    _settings.fullscreen
                );
            }
        }

        QualitySettings.vSyncCount =
            _settings.vSync ? 1 : 0;
    }
    
    private void LoadUI()
    {
        masterSlider.value = _settings.masterVolume;
        musicSlider.value = _settings.musicVolume;
        sfxSlider.value = _settings.sfxVolume;

        fullscreenToggle.isOn = _settings.fullscreen;

        int index = _resolutions.FindIndex(r =>
            r.width == _settings.resolutionWidth &&
            r.height == _settings.resolutionHeight
        );

        if (index < 0)
        {
            Resolution current = Screen.currentResolution;

            index = _resolutions.FindIndex(r =>
                r.width == current.width &&
                r.height == current.height
            );

            _settings.resolutionWidth = current.width;
            _settings.resolutionHeight = current.height;
        }

        if (index >= 0)
        {
            resolutionDropdown.value = index;
        }

        resolutionDropdown.RefreshShownValue();
    }

    private void ApplyVolume(string audioName, float value)
    {
        float volume = Mathf.Log10(value) * 20;

        if (value <= 0)
            volume = -80;

        audioMixer.SetFloat(audioName, volume);
    }
    
    private void LoadResolutions()
    {
        resolutionDropdown.ClearOptions();
        _resolutions.Clear();

        List<string> options = new List<string>();

        foreach (Resolution resolution in Screen.resolutions)
        {
            string option = $"{resolution.width}x{resolution.height}";

            if (!options.Contains(option))
            {
                options.Add(option);
                _resolutions.Add(resolution);
            }
        }

        foreach (string option in options)
        {
            resolutionDropdown.options.Add(
                new TMP_Dropdown.OptionData(option)
            );
        }

        resolutionDropdown.RefreshShownValue();
    }
}
