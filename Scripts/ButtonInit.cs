using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class ButtonInit : MonoBehaviour
{
    [SerializeField] private Button _button;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayButtonSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayButtonSound);
    }

    public void PlayButtonSound()
    {
        if (_audioSource != null)
            _audioSource.Play();
    }
}
