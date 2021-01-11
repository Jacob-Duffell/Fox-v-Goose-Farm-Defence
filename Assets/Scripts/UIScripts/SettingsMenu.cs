using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Handles logic for the Settings menu on the Hub Menu scene.
/// </summary>
public class SettingsMenu : MonoBehaviour
{
	[SerializeField] private AudioMixer mixer;
	[SerializeField] private GameObject musicSlider;
	[SerializeField] private GameObject sfxSlider;

	/// <summary>
	/// Initialises variables when the Hub Menu scene loads.
	/// </summary>
	private void Start()
	{
		musicSlider.GetComponent<Slider>().value = GameHandler.MusicVolume;
		sfxSlider.GetComponent<Slider>().value = GameHandler.SfxVolume;

		mixer.SetFloat("Music", Mathf.Log10(musicSlider.GetComponent<Slider>().value) * 20);
		mixer.SetFloat("SFX", Mathf.Log10(sfxSlider.GetComponent<Slider>().value) * 20);
	}

	/// <summary>
	/// Changes the music volume when the music slider value is changed.
	/// </summary>
	/// <param name="sliderValue"></param>
	public void SetMusicVolume(float sliderValue)
	{
		GameHandler.MusicVolume = sliderValue;

		mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
	}

	/// <summary>
	/// Changes the SFX volume when the SFX slider value is changed.
	/// </summary>
	/// <param name="sliderValue"></param>
	public void SetSFXVolume(float sliderValue)
	{
		GameHandler.SfxVolume = sliderValue;

		mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
	}
}
