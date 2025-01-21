using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UpdatePref : MonoBehaviour
{
    public Button EasyButton;
    public Button NormalButton;
    public Button HardButton;
    public Button ResetButton;

    // a tiny bit of the code for the sliders was from https://johnleonardfrench.music/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/
    public Slider MusicSlider;
    public Slider SoundSlider;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        // LoadPrefs();
        int Difficulty = PlayerPrefs.GetInt("Difficulty", 1); // 0 = easy, 1 = normal, 2 = hard
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        SoundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);

        EasyButton.onClick.AddListener(() => TaskOnClick(0)); // no idea why i need an arrow for this to work
        NormalButton.onClick.AddListener(() => TaskOnClick(1));
        HardButton.onClick.AddListener(() => TaskOnClick(2));
        ResetButton.onClick.AddListener(() => ResetPrefs());

        Debug.Log($"current difficulty: {PlayerPrefs.GetInt("Difficulty")}");
        Debug.Log($"current music volume: {PlayerPrefs.GetFloat("MusicVolume")}");
        Debug.Log($"current sound volume: {PlayerPrefs.GetFloat("SoundVolume")}");
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicSliderLevel(MusicSlider.value);
        SetSoundSliderLevel(SoundSlider.value);

        // Debug.Log(MusicSlider.value);
        // Debug.Log(SoundSlider.value);
    }

    public void TaskOnClick(int difficulty)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.Save();
        Debug.Log($"difficulty set to {difficulty}");
    }

    public void ResetPrefs()
    {
        MusicSlider.value = 0.5f;
        SoundSlider.value = 0.5f;
        Debug.Log("preferences reset");
    }

    public void SetMusicSliderLevel(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        mixer.SetFloat("MusicExposed", Mathf.Log10(value) * 20);
    }

    public void SetSoundSliderLevel(float value)
    {
        PlayerPrefs.SetFloat("SoundVolume", value);
        mixer.SetFloat("SoundExposed", Mathf.Log10(value) * 20);

    }
}
