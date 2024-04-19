using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioByTime : MonoBehaviour
{
    [SerializeField] private bool isPlaying = false;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private float timeToPlay = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayFootstepSounds());
    }

    IEnumerator PlayFootstepSounds()
    {
        while (true)
        {
            if (isPlaying)
            {
                audioSource.Play();
            }
            yield return new WaitForSeconds(timeToPlay);
        }
    }

    public void SetIsPlayingTrue()
    {
        isPlaying = true;
    }

    public void SetIsPlayingFalse()
    {
        isPlaying = false;
    }
}