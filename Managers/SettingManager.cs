using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour 
{
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureDropdown;
	public Dropdown antialiasingDropdown;
	public Dropdown vSyncDropdown;
	public Slider volumeSlider;
	public Button applyButton;


	public AudioSource musicSource;
	public Resolution[] resolutions;
	public GameSettings gameSettings;

	void OnEnable()
	{
		gameSettings = new GameSettings();

		fullscreenToggle.onValueChanged.AddListener(delegate {OnFullscreenToggle();});
		resolutionDropdown.onValueChanged.AddListener(delegate {OnResolutionChange();});
		textureDropdown.onValueChanged.AddListener(delegate {OnTextureChange();});
		antialiasingDropdown.onValueChanged.AddListener(delegate {OnAntiAliasingChange();});
		vSyncDropdown.onValueChanged.AddListener(delegate {OnVSyncChange();});
		volumeSlider.onValueChanged.AddListener(delegate {OnVolumeChange();});
		applyButton.onClick.AddListener(delegate {OnApplyButtonClick();});

		volumeSlider.value = musicSource.volume;


		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions)
		{
			resolutionDropdown.options.Add (new Dropdown.OptionData (resolution.ToString ()));
		}

		LoadSettings ();
	}

	public void OnFullscreenToggle()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}
		
	public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.ResolutionIndex = resolutionDropdown.value;
	}

	public void OnTextureChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.TextureQuality = textureDropdown.value;
	}

	public void OnAntiAliasingChange()
	{
		QualitySettings.antiAliasing = gameSettings.AntiAliasing = (int)Mathf.Pow (2, antialiasingDropdown.value);
	}

	public void OnVSyncChange()
	{
		QualitySettings.vSyncCount = gameSettings.Vsync = vSyncDropdown.value;
	}

	public void OnVolumeChange()
	{
		musicSource.volume = gameSettings.Volume = volumeSlider.value;
	}

	public void OnApplyButtonClick()
	{
		SaveSettings ();
	}

	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/GraveLordGameSettings.json", jsonData);
	}

	public void LoadSettings()
	{
		gameSettings = JsonUtility.FromJson<GameSettings> (File.ReadAllText(Application.persistentDataPath + "/GraveLordGameSettings.json"));

		fullscreenToggle.isOn = gameSettings.fullscreen;
		resolutionDropdown.value = gameSettings.ResolutionIndex;
		textureDropdown.value = gameSettings.TextureQuality;
		antialiasingDropdown.value = gameSettings.AntiAliasing;
		vSyncDropdown.value = gameSettings.Vsync;
		volumeSlider.value = gameSettings.Volume;

		resolutionDropdown.RefreshShownValue ();
	}


}
