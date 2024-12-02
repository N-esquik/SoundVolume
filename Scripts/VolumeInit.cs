using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeInit : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _volumeParameter;

    private float _lastValueVolume;
    private float _multiplier = 20f;
    private float _muteSound = -80f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void Start()
    {
        _lastValueVolume = PlayerPrefs.GetFloat(_volumeParameter, Mathf.Log10(_slider.value) * _multiplier);
        _slider.value = Mathf.Pow(10f, _lastValueVolume / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _lastValueVolume);
    }

    private void SetVolume(float volume)
    {
        _lastValueVolume = Mathf.Log10(volume) * _multiplier;
        _audioMixer.SetFloat(_volumeParameter, _lastValueVolume);
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.SetFloat(_volumeParameter, _muteSound);
        }
        else
        {
            _audioMixer.SetFloat(_volumeParameter, _lastValueVolume);
        }
    }
}