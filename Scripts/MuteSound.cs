using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _volumeParameter;

    private float _valueVolumeSound = -80f;
    private float _multiplier = 20f;
    private float _lastValueSound;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleMusic);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.SetFloat(_volumeParameter, _valueVolumeSound);
        }
        else
        {
            _audioMixer.SetFloat(_volumeParameter, SetSliderValue());
        }
    }

    private float SetSliderValue()
    {
        _lastValueSound = Mathf.Log10(_slider.value) * _multiplier;
        return _lastValueSound;
    }
}
