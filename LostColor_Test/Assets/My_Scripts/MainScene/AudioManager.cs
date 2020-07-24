using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject AudioOnOffRadio;
    [SerializeField] private GameObject AudioText;

    public Slider BGMVolumeSlider;
    public AudioSource BGMAudio;

    private float fBGMVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        fBGMVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        BGMVolumeSlider.value = fBGMVolume;
        BGMAudio.volume = BGMVolumeSlider.value;

        AudioOnOffRadio.GetComponent<Toggle>().isOn = true;
        AudioText.GetComponent<Text>().text = "On";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundSlider()
    {
        BGMAudio.volume = BGMVolumeSlider.value * 0.01f;
        fBGMVolume = BGMVolumeSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", fBGMVolume);
    }

    public void ClickedEnd_AudioOnOff()
    {
        if (AudioOnOffRadio.GetComponent<Toggle>().isOn)
        {
            BGMAudio.GetComponent<AudioSource>().Play();
            AudioText.GetComponent<Text>().text = "On";
        }
        else
        {
            BGMAudio.GetComponent<AudioSource>().Stop();
            AudioText.GetComponent<Text>().text = "Off";
        }
    }
}
