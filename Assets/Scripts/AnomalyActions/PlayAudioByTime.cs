using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioByTime : MonoBehaviour
{
    [SerializeField] private bool _isPlaying = false;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _timeToPlay = 1f;

    #region StartMethods
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayFootstepSounds());
    }
    #endregion

    #region Process Audio
    IEnumerator PlayFootstepSounds()
    {
        while (true)
        {
            if (_isPlaying)
            {
                _audioSource.Play();
            }
            yield return new WaitForSeconds(_timeToPlay);
        }
    }

    public void SetIsPlayingTrue()
    {
        _isPlaying = true;
    }

    public void SetIsPlayingFalse()
    {
        _isPlaying = false;
    }
    #endregion
}