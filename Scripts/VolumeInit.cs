using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeInit : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private string _volumeParameter;

    private float _lastValueVolume;
    private float _valueVolumeSound = -80f;
    private float _multiplier = 20f;
    private float _logaritmNumber = 10f;

    private void Start()
    {
        _lastValueVolume = PlayerPrefs.GetFloat(_volumeParameter, Mathf.Log10(_slider.value) * _multiplier);
        _slider.value = Mathf.Pow(_logaritmNumber, _lastValueVolume / _multiplier);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _lastValueVolume);
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        if (_toggle.isOn)
        {
            return;
        }
        else
        {
            if (volume > 0)
            {
                _lastValueVolume = Mathf.Log10(volume) * _multiplier;
                _audioMixer.SetFloat(_volumeParameter, _lastValueVolume);
            }
            else
            {
                _audioMixer.SetFloat(_volumeParameter, _valueVolumeSound);
            }
        }
    }
}