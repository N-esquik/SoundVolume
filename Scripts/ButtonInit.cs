using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class ButtonInit : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        if (_audioSource != null)
            _audioSource.Play();
    }
}
