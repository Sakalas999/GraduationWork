using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public static Volume Instance;
    [SerializeField] private Slider _volumeSlider = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadValues();
    }

    public void SaveVolume()
    {
        float volumeValue = _volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        _volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
